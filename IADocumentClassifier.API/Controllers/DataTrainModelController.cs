

namespace IADocumentClassifier.API.Controllers
{
    using AutoMapper;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DataTrainModelController : ControllerBase
    {
        private readonly IBlobServices _blobServices;
        private readonly ISetupServices _setupServices;
        private readonly IMapper _mapper;
        private readonly int Const_Setup04 = 4; //parametro de configuración blob storage
        private CloudBlobContainer blobContainer;

        public DataTrainModelController(IBlobServices blobServices, ISetupServices setupServices, IMapper mapper)
        {
            _blobServices = blobServices;
            _setupServices = setupServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar archivos o modelos entrenados
        /// </summary>
        /// <param name="ConfigurationParameter_id"></param>
        /// <param name="containerName"></param>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFilesTrained(int ConfigurationParameter_id, string containerName)
        {
            if (Const_Setup04 != ConfigurationParameter_id)
            {
                return BadRequest();
            }

            string connectionString = await GetConnectionBlobStorage(ConfigurationParameter_id);

            List<BlobFile> ItemList = new List<BlobFile>();

            ItemList = await _blobServices.GetAll(connectionString, containerName);
            var jsonResult = System.Text.Json.JsonSerializer.Serialize(ItemList);
            return Ok(jsonResult);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateContainer(int ConfigurationParameter_id, string containerName)
        //{
        //    if (Const_Setup04 != ConfigurationParameter_id)
        //    {
        //        return BadRequest(false);
        //    }

        //    string connectionString = await GetConnectionBlobStorage(ConfigurationParameter_id);

        //    // Check if Container Name is null or empty  
        //    if (string.IsNullOrEmpty(containerName))
        //    {
        //        throw new ArgumentNullException("ContainerName", "Container Name can't be empty");
        //    }
        //    try
        //    {
        //        // Get azure table storage connection string.  
        //        string ConnectionString = "Your Azure Storage Connection String goes here";
        //        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

        //        CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
        //        blobContainer = cloudBlobClient.GetContainerReference(containerName);

        //        // Create the container and set the permission  
        //        if (await blobContainer.CreateIfNotExistsAsync())
        //        {
        //            await blobContainer.SetPermissionsAsync(
        //                new BlobContainerPermissions
        //                {
        //                    PublicAccess = BlobContainerPublicAccessType.Blob
        //                }
        //            );
        //        }
        //        return Ok(true);
        //    }
        //    catch (Exception ExceptionObj)
        //    {
        //        throw ExceptionObj;
        //    }
        //}

        /// <summary>
        ///  Metodo para subir archivos para entrenamiento de modelos
        /// </summary>
        /// <param name="ConfigurationParameter_id"></param>
        /// <param name="containerName"></param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpLoadFile(int ConfigurationParameter_id, string containerName, string filePath, string fileName)
        {
            if (Const_Setup04 != ConfigurationParameter_id)
            {
                return BadRequest();
            }

            string connectionString = await GetConnectionBlobStorage(ConfigurationParameter_id);

            var result = await _blobServices.UpLoadContentBlob(connectionString, containerName, filePath, fileName);
            return Ok(result);
        }

        private async Task<string> GetConnectionBlobStorage(int ConfigurationParameter_id)
        {
            var configuration = await _setupServices.GetById(ConfigurationParameter_id);
            var setDto = _mapper.Map<SetupDTO>(configuration);
            var connectionString = setDto.ValueParameter;
            return connectionString;
        }

        /// <summary>
        /// Metodo para remover el contenedor de archivos
        /// </summary>
        /// <param name="ConfigurationParameter_id"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int ConfigurationParameter_id, string containerName)
        {
            if (Const_Setup04 != ConfigurationParameter_id)
            {
                return BadRequest();
            }

            string connectionString = await GetConnectionBlobStorage(ConfigurationParameter_id);
            var result = await _blobServices.DeleteContainer(connectionString, containerName);
            return Ok(result);
        }

    }
}
