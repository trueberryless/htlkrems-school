using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Azure_Storage_Account_Access
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Take a local textfile and upload it to the storage account into a container called “pupils”.
            // The text file should be named after you (Firstname_Lastname.txt) and contain a short message like “all your base are belong to us”. 

            var blobServiceClient = new BlobServiceClient(
                "DefaultEndpointsProtocol=https;AccountName=5ahit20230915;AccountKey=PwpRb18COtK26fuUIO2FiKU/KXwtCeP/8rhQk5RSZ/nBDAkUV2LhhiDVOfIeazXHGgA7U5yIrpaY+ASt/Wwdsg==;EndpointSuffix=core.windows.net");

            //Create a unique name for the container
            string containerName = "pupils";

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            // Create a local file in the ./data/ directory for uploading and downloading
            string localPath = "data";
            Directory.CreateDirectory(localPath);
            string fileName = "Felix_Schneider" + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write text to the file
            await File.WriteAllTextAsync(localFilePath, "This sentence is false!");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file
            await blobClient.UploadAsync(localFilePath, true);

            Console.WriteLine("Listing blobs...");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }

            // 2. Download the previously uploaded textfile and save it under as Firstname_Lastname_Timestamp.txt on your local hard drive. 
            
            // Download the blob to a local file
            // Append the string "DOWNLOADED" before the .txt extension 
            // so you can compare the files in the data directory
            string downloadFilePath = localFilePath.Replace(".txt", "_Timestamp.txt");

            Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

            // Download the blob's contents and save it to a file
            await blobClient.DownloadToAsync(downloadFilePath);
            
            // 3. Make an entry into a table called “pupiltable”. You should have a column for each of these fields: Firstname, Lastname, DateOfBirth
            // Use "pupils" as a PartitionKey and a unique identifier for you as the RowKey.
            var partitionKey = "pupils";
            
            
            // Construct a new "TableServiceClient using a TableSharedKeyCredential.

            var serviceClient = new TableServiceClient(
                "DefaultEndpointsProtocol=https;AccountName=5ahit20230915;AccountKey=PwpRb18COtK26fuUIO2FiKU/KXwtCeP/8rhQk5RSZ/nBDAkUV2LhhiDVOfIeazXHGgA7U5yIrpaY+ASt/Wwdsg==;EndpointSuffix=core.windows.net");
            
            // Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.
            var tableName = "pupiltable";
            Pageable<TableItem> queryTableResults = serviceClient.Query(filter: $"TableName eq '{tableName}'");

            Console.WriteLine("The following are the names of the tables in the query results:");

            // Iterate the <see cref="Pageable"> in order to access queried tables.

            foreach (TableItem table in queryTableResults)
            {
                Console.WriteLine(table.Name);
            }
            
            // Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
            var tableClient = new TableClient(
                "DefaultEndpointsProtocol=https;AccountName=5ahit20230915;AccountKey=PwpRb18COtK26fuUIO2FiKU/KXwtCeP/8rhQk5RSZ/nBDAkUV2LhhiDVOfIeazXHGgA7U5yIrpaY+ASt/Wwdsg==;EndpointSuffix=core.windows.net",
                tableName);

            // Make a dictionary entity by defining a <see cref="TableEntity">.
            var tableEntity = new TableEntity(partitionKey, "Felix_Schneider")
            {
                { "Firstname", "Felix" },
                { "Lastname", "Schneider" },
                { "DateOfBirth", "20.02.2005" }
            };


            // Add the newly created entity.
            await tableClient.AddEntityAsync(tableEntity);
            
            // 4. Read data from the table. List all entries (the entry made by you and by others in class) and output it in the console.
            
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                Console.WriteLine($"{qEntity.GetString("Firstname")} {qEntity.GetString("Lastname")}  born {qEntity.GetString("DateOfBirth")}");
            }

            Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
            
            // 5. Write a message in a storage queue called “greetings”.

            QueueServiceClient queueServiceClient = new QueueServiceClient(
                "DefaultEndpointsProtocol=https;AccountName=5ahit20230915;AccountKey=PwpRb18COtK26fuUIO2FiKU/KXwtCeP/8rhQk5RSZ/nBDAkUV2LhhiDVOfIeazXHGgA7U5yIrpaY+ASt/Wwdsg==;EndpointSuffix=core.windows.net");

            QueueClient queueClient = queueServiceClient.GetQueueClient("greetings");
            
            Console.WriteLine("\nAdding messages to the queue...");

            // Send several messages to the queue
            await queueClient.SendMessageAsync("Felix Schneider says: Welcome, Clemens Schlipfinger!");
            await queueClient.SendMessageAsync("Felix Schneider says: Welcome, Jakob Pusch!");

            // Save the receipt so we can update this message later
            SendReceipt receipt = await queueClient.SendMessageAsync("Third message");

            // 6. Write a message consumer that listens for messages being added and displays the content of the message in the console.*/
            
            Console.WriteLine("\nPeek at the messages in the queue...");

            while (true)
            {
                // Peek at messages in the queue
                PeekedMessage[] peekedMessages = await queueClient.PeekMessagesAsync();

                foreach (PeekedMessage peekedMessage in peekedMessages)
                {
                    // Display the message
                    Console.WriteLine($"Message: {peekedMessage.MessageText}");
                }
                
                Thread.Sleep(1000);
            }
        }
    }
}