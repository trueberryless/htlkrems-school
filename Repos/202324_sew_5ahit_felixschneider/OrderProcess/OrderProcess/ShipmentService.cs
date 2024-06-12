using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace OrderProcess;

public static class ShipmentService
{
    [FunctionName("PackageItems")]
    public static async Task<List<Shipment>> PackageItems([ActivityTrigger] Order order, ILogger log)
    {
        log.LogInformation($"Package Items");

        var shipments = new List<Shipment>();

        while (order.OrderItems.Count > 0)
        {
            int sublistSize = new Random().Next(1, 3);
            var sublist = order.OrderItems.GetRange(0, Math.Min(sublistSize, order.OrderItems.Count));

            // Remove the extracted elements from the inputList
            order.OrderItems.RemoveRange(0, sublist.Count);

            // Add the sublist to the result
            shipments.Add(new Shipment()
            {
                Order = order, Items = sublist, TotalPrice = sublist.Sum(i => i.Price),
                ItemCount = sublist.Count
            });
        }

        return shipments;
    }
    
    [FunctionName("ShipItems")]
    public static async Task Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "extern-event")]
        HttpRequest req,
        [DurableClient] IDurableOrchestrationClient client,
        ILogger log)
    {
        log.LogInformation("One Package delivered.");
        await client
            .RaiseEventAsync(req.Query["id"], "ApprovalShipment", true);
    }
}