using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using Backend.Interfaces.Services;
using Azure.Identity;

namespace Backend.Services
{
    public class AzureObjectStoreService :IAzureObjectStoreService
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly ILogger<AzureObjectStoreService> logger;

        public AzureObjectStoreService(IConfiguration configuration,ILogger<AzureObjectStoreService> logger)
        {
            _connectionString = configuration["AzureBlobConfig:connectionString"];
            _containerName = configuration["AzureBlobConfig:containerName"];
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">usually a byte array</param>
        /// <param name="driveName">the folder or drive</param>
        /// <param name="folderName">containter name</param>
        /// <param name="fileName">the name of the file should also contain the extension</param>
        /// <returns></returns>
        public async Task<Guid> Create(object item, string fileName, string? folderName = default)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            string s = folderName ?? _containerName;
            BlobContainerClient containerClient=blobServiceClient.GetBlobContainerClient(folderName ?? _containerName);

          
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            logger.LogInformation("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file, overwrite the blob if it already exists
            await blobClient.UploadAsync((Stream)item, true);
            return default;
        }

        public Task<bool> Delete(string folderName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<object> Read(string folderName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(object item, string folderName, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
