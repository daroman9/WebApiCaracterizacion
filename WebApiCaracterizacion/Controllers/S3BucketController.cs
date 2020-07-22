using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwsFiles.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwsFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : ControllerBase
    {
        private readonly IS3Service _service;

        public S3BucketController(IS3Service service)
        {
            _service = service;
        }

        [HttpPost("{bucketName}")]
        public async Task<IActionResult> CreateBucket([FromRoute] string bucketName)
        {
            var response = await _service.CreateBucketAsync(bucketName);
            return Ok(response);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadFiles/{bucketName}")]
        public async Task<IActionResult> UploadFile([FromRoute]string bucketName)
        {
            var file = Request.Form.Files[0];

            var response = await _service.UploadFileAsync(bucketName, file);

            if (response.Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}