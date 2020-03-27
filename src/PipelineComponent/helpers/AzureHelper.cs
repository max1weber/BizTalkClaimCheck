
using Microsoft.Azure.Storage.Auth;
using System;
using System.IO;

namespace PipelineComponents
{
    public class AzureHelper
    {
        public static Stream DownloadObject(string storageName, string objectName, string name, string serviceAccountName, string serviceAccountKey, string clientId, Stream objectStream)
        {
            if (objectStream is null)
            {
                throw new ArgumentNullException(nameof(objectStream));
            }

            StorageCredentials storageCredentials = new StorageCredentials(serviceAccountName, serviceAccountKey);


            Microsoft.Azure.Storage.CloudStorageAccount account = new Microsoft.Azure.Storage.CloudStorageAccount(storageCredentials, true);

            ///TO DO : Get all other thins done download file or something
            

            return objectStream;
           
        }
    }
}