using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using IADocumentClassifier.Cors.CustomEntities;
using IADocumentClassifier.Cors.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IADocumentClassifier.Cors.Services
{
    public class BlobServices : IBlobServices
    {

        public async Task<List<BlobFile>> GetAll(string connectionString, string containerName)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

            // List all blobs in the containerName
            List<BlobFile> ItemList = new List<BlobFile>();

            var blobs = blobContainerClient.GetBlobs();
            foreach (BlobItem blobItem in blobs)
            {
                ItemList.Add(new BlobFile(){ FileName = blobItem.Name, CreatedOn = blobItem.Properties.CreatedOn.Value.UtcDateTime } );
            }
            return ItemList;
        }

        public async Task<bool> UpLoadContentBlob(string conectionString, string containerName, string filePath, string fileName)
        {
            try
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(conectionString, containerName);

                string localFilePath = Path.Combine(filePath, fileName);

                // Get a reference to a blob
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                // Open the file and upload its data
                FileStream uploadFileStream = File.OpenRead(localFilePath);
                var result = await blobClient.UploadAsync(uploadFileStream, true);
                uploadFileStream.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<bool> DeleteContainer(string connectionString, string containerName)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            await blobContainerClient.DeleteAsync();
            return true;
        }
    }
}
