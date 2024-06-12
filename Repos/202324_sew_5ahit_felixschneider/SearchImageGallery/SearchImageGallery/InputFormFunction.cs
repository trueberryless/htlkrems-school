using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SearchImageGallery;

public static class InputFormFunction
{
    [FunctionName("InputFormFunction")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "input-form")] HttpRequest req, ILogger log)
    {
        
        log.LogInformation("C# HTTP trigger function processed a request.");

        var blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
            string containerName = "webpages";
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        string localPath = "data";
        Directory.CreateDirectory(localPath);
        string fileName = "search.html";
        string localFilePath = Path.Combine(localPath, fileName);

        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        log.LogInformation("\nDownloading blob to\n\t{0}\n", localFilePath);

        // Download the blob's contents and save it to a file
        await blobClient.DownloadToAsync(localFilePath);

        var htmlContent = File.ReadAllText(localFilePath);

        return new ContentResult()
        {
            Content = htmlContent,
            ContentType = "text/html",
            StatusCode = StatusCodes.Status200OK
        };
    }
}