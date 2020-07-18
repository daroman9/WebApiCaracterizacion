using AwsFiles.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AwsFiles.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);

        Task<S3Response> UploadFileAsync(String bucketName, IFormFile file);
    }
}