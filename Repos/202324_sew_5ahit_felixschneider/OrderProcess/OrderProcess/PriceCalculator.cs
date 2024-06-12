using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace OrderProcess;

public static class PriceCalculator
{
    [FunctionName("GetItemInformation")]
    public static async Task<Order> GetItemInformation([ActivityTrigger] Order order, ILogger log)
    {
        log.LogInformation($"Getting Item Prices.");

        // price for each item
        foreach (var orderItem in order.OrderItems)
        {
            orderItem.Price = new Random().Next(10, 100) * orderItem.Quantity;
        }

        // calculate total price
        order.TotalPrice = order.OrderItems.Sum(i => i.Price);

        return order;
    }
}