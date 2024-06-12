using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OrderProcess;

public static class PreOrder
{
    [FunctionName("PlaceOrder")]
    public static async Task<IActionResult> PlaceOrder(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        var order = JsonConvert.DeserializeObject<Order>(requestBody);

        // Function input comes from the request content.
        string instanceId = await starter.StartNewAsync("ProcessOrder", null, order);

        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

        return starter.CreateCheckStatusResponse(req, instanceId);
    }
}