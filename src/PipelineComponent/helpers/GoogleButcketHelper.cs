
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;

namespace PipelineComponents
{
    public class GoogleButcketHelper
    {
        public static async System.Threading.Tasks.Task<Stream> DownloadObjectAsync(string bucket, string objectName, string name, string serviceAccountName, string serviceAccountKeyFile, string clientId, Stream objectStream)
        {
            if (objectStream is null)
            {
                throw new ArgumentNullException(nameof(objectStream));
            }
            var credential = GoogleCredential.FromFile(serviceAccountKeyFile);

            using (StorageClient storageClient = StorageClient.Create(credential))
            {
                DownloadObjectOptions options = new DownloadObjectOptions() { DownloadValidationMode = DownloadValidationMode.Always };

                await storageClient.DownloadObjectAsync(bucket, objectName, objectStream, options);

                
            }

            return objectStream;
        }
    }
}