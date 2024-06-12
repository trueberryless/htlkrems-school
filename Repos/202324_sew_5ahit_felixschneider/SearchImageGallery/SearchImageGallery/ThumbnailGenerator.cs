using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace SearchImageGallery;

public static class ThumbnailGenerator
{
    [FunctionName("ThumbnailGenerator")]
    public static async Task RunAsync(
        [BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")] Stream imageStream,
        [Blob("thumbnails/{name}", FileAccess.Write)] Stream thumbnailStream,
        string name,
        ILogger log)
    {
        log.LogInformation($"Processing image {name}");

        using var image = await SixLabors.ImageSharp.Image.LoadAsync(imageStream);
        var newWidth = 300;
        var newHeight = 200;

        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(newWidth, newHeight),
            Mode = ResizeMode.Max
        }));

        await image.SaveAsync(thumbnailStream, new JpegEncoder()); // Save as JPEG, change format as needed
    }
}