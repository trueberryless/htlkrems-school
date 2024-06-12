using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchImageGallery;

public static class SearchFunction
{
    [FunctionName("SearchFunction")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "search")]
        HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string searchString = req.Form["inputField"];

        log.LogInformation(searchString);

        string apiKey = "4zBBIblJe2t6k19GuSNsNmyyx98a78tdt0AS4xVzLlg";
        string apiUrl = $"https://api.unsplash.com/search/photos?query={searchString}&client_id={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    
                    JObject jsonObject = JObject.Parse(jsonResult);

                    // Access RAW URLs
                    List<RawImage> rawUrls = new List<RawImage>();

                    foreach (JObject item in jsonObject["results"].Take(20))
                    {
                        string rawUrl = (string)item["urls"]["raw"];
                        rawUrls.Add(new RawImage(searchString, rawUrl));
                    }
                    
                    if (rawUrls.Count > 0)
                    {
                        foreach (RawImage rawUrl in rawUrls)
                        {
                            Console.WriteLine(rawUrl.Url);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No RAW URLs found.");
                    }
                    
                    string queueName = "images";

                    QueueServiceClient queueServiceClient = new QueueServiceClient("UseDevelopmentStorage=true");
                    QueueClient queueClient = queueServiceClient.GetQueueClient(queueName);
                    
                    foreach (var rawUrl in rawUrls)
                    {
                        // Send several messages to the queue
                        await queueClient.SendMessageAsync(JsonConvert.SerializeObject(rawUrl));
                        Console.WriteLine(JsonConvert.SerializeObject(rawUrl));
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        return new RedirectResult($"/api/gallery?search={searchString}");
    }
}