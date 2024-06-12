using System.Threading.Tasks;
using System;
using System.IO;
using System.Net.Http;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json.Linq;

namespace SearchImageGallery;

public static class ImageLoader
{
    [FunctionName("ImageLoader")]
    public static async Task RunAsync(
        [QueueTrigger("images", Connection = "AzureWebJobsStorage")]
        string jsonString, ILogger log)
    {
        log.LogInformation($"C# Queue trigger function processed: {jsonString}");

        try
        {
            JObject jsonObject = JObject.Parse(jsonString);
            string url = jsonObject["Url"].ToString();
            string tag = jsonObject["Tag"].ToString();
            string type = jsonObject["Type"].ToString();

            string localPath = "images";
            Directory.CreateDirectory(localPath);
            string fileName = $"{tag}_{type}_{Guid.NewGuid()}.jpg";
            string localFilePath = Path.Combine(localPath, fileName);

            await DownloadImageAsync(url, localFilePath);

            var blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
            string containerName = "images";
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file
            await blobClient.UploadAsync(localFilePath, true);
        }
        catch (Exception ex)
        {
            log.LogError($"Error processing image: {ex.Message}");
        }
    }

    static async Task DownloadImageAsync(string imageUrl, string localFilePath)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                // Download the image content as a byte array
                byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                // Write the image bytes to a local file
                using (FileStream fileStream = File.Create(localFilePath))
                {
                    await fileStream.WriteAsync(imageBytes, 0, imageBytes.Length);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error downloading the image: {ex.Message}");
            }
        }
    }
}