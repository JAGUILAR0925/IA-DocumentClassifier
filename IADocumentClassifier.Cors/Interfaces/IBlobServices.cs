
namespace IADocumentClassifier.Cors.Interfaces
{
    using Azure.Storage.Blobs.Models;
    using IADocumentClassifier.Cors.CustomEntities;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBlobServices
    {
        Task<List<BlobFile>> GetAll(string connectionString, string containerName);
        Task<bool> UpLoadContentBlob(string conectionString, string containerName, string filePath, string fileName);
        Task<bool> DeleteContainer(string connectionString, string containerName);
    }
}
