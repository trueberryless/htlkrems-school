using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace SearchImageGallery;

public static class GalleryService
{
    [FunctionName("GalleryService")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "gallery")] HttpRequest req,
        ILogger log)
    {
        // Parse query parameter
        string searchTerm = req.Query["search"];
        
        log.LogInformation($"C# HTTP trigger function processed a request with term: {searchTerm}");

        // Thumb URL, RAW URL
        Dictionary<string, string> images = new Dictionary<string, string>();

        var blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
        string thumbnailsName = "thumbnails";
        
        BlobContainerClient thumbnailsClient = blobServiceClient.GetBlobContainerClient(thumbnailsName);
        string imageName = "images";
        
        BlobContainerClient imagesClient = blobServiceClient.GetBlobContainerClient(imageName);
        
        await foreach (BlobItem blobItem in thumbnailsClient.GetBlobsAsync())
        {
            var thumbnailClient = thumbnailsClient.GetBlobClient(blobItem.Name);
            var imageClient = imagesClient.GetBlobClient(blobItem.Name);
            
            if (!thumbnailClient.Name.Contains(searchTerm))
                continue;
            
            var thumbnailLink = thumbnailClient.Uri;
            var imageLink = imageClient.Uri;
            
            images.Add(thumbnailLink.ToString(), imageLink.ToString());
        }

        string htmlResponse = await GenerateHtmlResponseAsync(searchTerm, images);

        return new ContentResult
        {
            Content = htmlResponse,
            ContentType = "text/html",
            StatusCode = 200
        };
    }

    private static async Task<string> GenerateHtmlResponseAsync(string searchTerm, Dictionary<string, string> imageUrls)
    {
        var blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
        string containerName = "webpages";
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        string localPath = "data";
        Directory.CreateDirectory(localPath);
        string fileName = "index.html";
        string localFilePath = Path.Combine(localPath, fileName);

        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        // Download the blob's contents and save it to a file
        await blobClient.DownloadToAsync(localFilePath);
        
        var htmlContent = File.ReadAllText(localFilePath);

        var imageContent = "";
        var counter = 0;

        foreach (var imageUrl in imageUrls.Take(4))
        {
            counter++;
            imageContent += $"<a href='{imageUrl.Value}' data-lightbox='pictures' data-title='{searchTerm}'><img src='{imageUrl.Key}' id='_{counter}'></a>";
        }

        htmlContent = htmlContent.Replace("# IMAGES #", imageContent);
        htmlContent = htmlContent.Replace("# SEARCHTERM #", searchTerm);
        
        BlobClient lightboxCSSClient = containerClient.GetBlobClient("css/lightbox.css");
        BlobClient styleCSSClient = containerClient.GetBlobClient("css/style.css");
        BlobClient lightboxJSClient = containerClient.GetBlobClient("js/lightbox-plus-jquery.js");
        
        htmlContent = htmlContent.Replace("# lightboxCSSLink #", lightboxCSSClient.Uri.ToString());
        htmlContent = htmlContent.Replace("# styleCSSLink #", styleCSSClient.Uri.ToString());
        htmlContent = htmlContent.Replace("# lightboxJSLink #", lightboxJSClient.Uri.ToString());

        return htmlContent;
    }
}