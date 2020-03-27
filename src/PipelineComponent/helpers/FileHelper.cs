
using System;
using System.IO;

namespace PipelineComponents
{
    public class FileHelper
    {
        public static async System.Threading.Tasks.Task<Stream> DownloadObjectAsync(string directorypath, string objectName, string name, string serviceAccountName, string serviceAccountKey, string clientId, Stream objectStream)
        {
            if (objectStream is null)
            {
                throw new ArgumentNullException(nameof(objectStream));
            }

            string fullpath = Path.Combine(directorypath, objectName);

            if (!File.Exists(fullpath))
            {
                throw new ArgumentException(string.Format(" File {0} doesn't exists !", fullpath));


            }

            
                using (FileStream file = new FileStream(fullpath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];

                    await file.ReadAsync(bytes, 0, (int)file.Length);
                    await objectStream.WriteAsync(bytes, 0, (int)file.Length);

                }

            objectStream.Position = 0;
            return objectStream;

        }
    }
}