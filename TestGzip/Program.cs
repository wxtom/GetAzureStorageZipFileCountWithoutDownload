using System.IO;
using System.IO.Compression;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace TestGzip
{
    class Program
    {
        static void Main(string[] args)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("connectionstring");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("testcont");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("azureCredential.zip");

            using (var memoryStream = new MemoryStream())
            {
                blockBlob.DownloadToStream(memoryStream);
                using (ZipArchive zip = new ZipArchive(memoryStream))
                {
                    var count = zip.Entries.Count;
                }
            }

        }
    }
}

