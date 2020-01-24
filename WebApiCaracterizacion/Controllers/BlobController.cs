using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace WebApiCaracterizacion.Controllers
{
    //[ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BlobController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("api/UploadFiles")]
        public async Task<IActionResult> SaveProfilePicaAsync(IFormFile file)
        {
            var storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=blobcaracterizacion;AccountKey=5e/DpUB+xAEoQx1MTuZrDi0CT99skZsDP6byglGa4UCAs4gBaAq2ddIqxa33UUYlmqDlfFNlkP2etz5aZiofIA==;EndpointSuffix=core.windows.net";
            if (CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");
                await container.CreateIfNotExistsAsync();

                var picBlob = container.GetBlockBlobReference(file.FileName);

                await picBlob.UploadFromStreamAsync(file.OpenReadStream());
                return Ok("Archivo cargado con exito");
            }
            return BadRequest("Ocurrio un error al subir el archivo");
        }


    }

}