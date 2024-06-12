using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderProcess;

public static class ProcessOrder
{
    [FunctionName("ProcessOrder")]
    public static async Task RunOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context,
        [Microsoft.Azure.WebJobs.Table("OrderTable")] TableClient orderClient,
        ILogger log)
    {
        log.LogInformation("Durable Function Start.");

        var startTime = context.CurrentUtcDateTime;

        var order = context.GetInput<Order>();

        order = await context.CallActivityAsync<Order>("GetItemInformation", order);
        await context.CallActivityAsync("SendConfirmationMail", order);
        var shipments = await context.CallActivityAsync<List<Shipment>>("PackageItems", order);

        var shipmentStart = context.CurrentUtcDateTime;
        var shipmentTimes = new Dictionary<Shipment, double>();

        foreach (var shipment in shipments)
        {
            // wait for extern event
            var approved = await context
                .WaitForExternalEvent<bool>("ApprovalShipment");

            shipmentTimes.Add(shipment, (DateTime.UtcNow - shipmentStart).TotalMilliseconds);
            log.LogInformation($"Shipment took {shipmentTimes[shipment]}ms.");
        }

        await context.CallActivityAsync("SendOrderExecutedMail", shipments);

        var orderTime = (DateTime.UtcNow - startTime).TotalMilliseconds;
        log.LogInformation($"Order completed in {orderTime}ms.");
        log.LogInformation("Durable Function End.");

        log.LogInformation($"""
                        OrderTime: {orderTime}
                        ShipmentTimes: {string.Join("; ", shipmentTimes.Select(s => s.Value))}
                        ShipmentCosts: {string.Join("; ", shipments.Select(s => s.TotalPrice))}
                        ItemCount: {string.Join("; ", shipments.Select(s => s.ItemCount))}
                        """);

        var tableEntity = new OrderTable()
        {
            PartitionKey = "order",
            RowKey = Guid.NewGuid().ToString(),
            OrderTime = orderTime,
            ShipmentTimes = string.Join("; ", shipmentTimes.Select(s => s.Value)),
            ShipmentCosts = string.Join("; ", shipments.Select(s => s.TotalPrice)),
            ItemCount = string.Join("; ", shipments.Select(s => s.ItemCount))
        };
        
        orderClient.AddEntity(tableEntity);
    }
}