using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.Helpers
{
    public class AzureBlobManager
    {
        private CloudBlobContainer blobContainer;
        private bool _isInitialized = false;
        public AzureBlobManager(string ContainerName, string ConnectionString)
        {
            if (string.IsNullOrEmpty(ContainerName))
            {
                throw new ArgumentNullException("ContainerName", "Container name can't be empty");
            }
            try
            {
                // string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=fawa;AccountKey=1P58ebBNoZHi1NPISXJakHysOyeCmqVSdi0l4R60F3WFQ5CMNr6vQedl/QUUv3hKaDIW2PmjDtJykZ32BrAJOA==;EndpointSuffix=core.windows.net";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                blobContainer = cloudBlobClient.GetContainerReference(ContainerName.ToLower().Replace(" ", "-"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Init()
        {
            try
            {
                // Create the container and set the permission
                var isCreated = await blobContainer.CreateIfNotExistsAsync();
                if (isCreated)
                {
                    await blobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                }
                _isInitialized = true;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadFile(FileInfo fileinfo, string newName)
        {
            string AbsoluteUri;
            // Check HttpPostedFileBase is null or not  
            if (fileinfo == null || !fileinfo.Exists)
                return null;

            if (_isInitialized == false)
            {
                throw new Exception("Initizalized must be called first!");
            }

            try
            {

                CloudBlockBlob blockBlob;
                // Create a block blob  
                blockBlob = blobContainer.GetBlockBlobReference(newName);
                // Set the object's content type  
                //  blockBlob.Properties.ContentType = FileToUpload.ContentType;
                // upload to blob  
                using (var fs = fileinfo.OpenRead())
                {
                    await blockBlob.UploadFromStreamAsync(fs);
                }
                // get file uri  
                AbsoluteUri = blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
            return AbsoluteUri;
        }
        //public async Task<List<string>> BlobList()
        //{
        //    List<string> _blobList = new List<string>();
        //    foreach (IListBlobItem item in await blobContainer.ListBlobsSegmentedAsync()
        //    {
        //        if (item.GetType() == typeof(CloudBlockBlob))
        //        {
        //            CloudBlockBlob _blobpage = (CloudBlockBlob)item;
        //            _blobList.Add(_blobpage.Uri.AbsoluteUri.ToString());
        //        }
        //    }
        //    return _blobList;
        //}
        public async Task<bool> DeleteBlob(string AbsoluteUri)
        {
            try
            {
                Uri uriObj = new Uri(AbsoluteUri);
                string BlobName = Path.GetFileName(uriObj.LocalPath);

                // get block blob refarence  
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(BlobName);

                // delete blob from container      
                await blockBlob.DeleteAsync();
                return true;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
        public async Task CopyTo(string fileName, string targetPath)
        {
            if (_isInitialized == false)
            {
                throw new Exception("Initizalized must be called first!");
            }
            var fileRef = blobContainer.GetBlobReference(fileName);
            if (!fileRef.ExistsAsync().Result)
                Console.WriteLine("File " + fileRef.Name + " doesn't exist");
            fileRef.DownloadToFileAsync(targetPath, FileMode.Create).Wait();
        }
    }

}
