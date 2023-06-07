using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlobFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=filetestmanju;AccountKey=j6o3mNgwp4yiRKHLDw+xTKqua9pdLBXrHx0iUPkSnTpNy7XpZlPEEvp6fonVTrXvAXtbA5il9PK2+AStaVRykA==;EndpointSuffix=core.windows.net";

        [HttpPost]
        public async Task<ActionResult> UploadFileToStorage(IList<IFormFile> files)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(ConnectionString,"storagemanju");
            foreach (IFormFile file in files)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    await blobContainerClient.UploadBlobAsync($"folder1/folder2/{file.FileName}",stream);
                }
            }

            return Ok("Files Uploaded Successfully");

        }
    }
}
