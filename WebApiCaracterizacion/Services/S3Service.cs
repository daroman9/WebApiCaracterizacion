using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using AwsFiles.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AwsFiles.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _client;

        public S3Service(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<S3Response> CreateBucketAsync(string bucketName)
        {
            try
            {
                if (await AmazonS3Util.DoesS3BucketExistAsync(_client, bucketName) == false)
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };
                    var response = await _client.PutBucketAsync(putBucketRequest);

                    return new S3Response
                    {
                        Message = response.ResponseMetadata.RequestId,
                        Status = response.HttpStatusCode
                    };
                }


            }
            catch (AmazonS3Exception e)
            {
                return new S3Response
                {
                    Status = e.StatusCode,
                    Message = e.Message

                };
            }
            catch (Exception e)
            {
                return new S3Response
                {
                    Status = System.Net.HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

            }
            return new S3Response
            {
                Status = System.Net.HttpStatusCode.InternalServerError,
                Message = "Hubo un error al crear el bucket"
            };

        }

        public async Task<S3Response> UploadFileAsync(String bucketName, IFormFile file)
        {
            try
            {
                var transferRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = file.OpenReadStream(),
                    AutoCloseStream = false,
                    BucketName = bucketName,
                    Key = file.FileName,
                    StorageClass = S3StorageClass.Standard
                };

                transferRequest.Metadata.Add("Date-UTC-Uploaded", DateTime.UtcNow.ToString());


                await new TransferUtility(_client).UploadAsync(transferRequest);

                return new S3Response()
                {
                    Message = "File Uploaded",
                    Status = System.Net.HttpStatusCode.OK
                };
            }
            catch (AmazonS3Exception e)
            {
                Debug.WriteLine(e.Message);
                return new S3Response()
                {
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Message = e.Message
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new S3Response()
                {
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Message = e.Message
                };
            }
        }

    }

}
