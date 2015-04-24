using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace GlobalAzureBootcampReport.Azure
{
    public static class AzureHelper
    {
        private static CloudStorageAccount _account;

        public static CloudStorageAccount CloudStorageAccount
        {
            get
            {
                if (_account != null)
                {
                    return _account;
                }
                var connectionString = ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("You should provide a value for the storage connection string");
                }
                _account = CloudStorageAccount.Parse(connectionString);
                return _account;
            }
        }
        
        /// <summary>
        /// Helper method that returns the Azure table with the supplied <paramref name="tableName"/>
        /// </summary>
        public static CloudTable GetTableReference(string tableName)
        {
            var account = CloudStorageAccount;

            var tableReference = account.CreateCloudTableClient().GetTableReference(tableName);
            tableReference.CreateIfNotExists();
            return tableReference;
        }

        public static CloudBlobContainer GetContainerReference(string containerName)
        {
            var blobClient = CloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess =
                        BlobContainerPublicAccessType.Blob
                });
            return container;
        }
    }
}