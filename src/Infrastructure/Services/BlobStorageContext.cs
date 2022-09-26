using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.Exceptions;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Infrastructure.Services;

public class BlobStorageContext: IBlobStorageContext
{

    private readonly ILogger<BlobStorageContext> _logger;

    private readonly MinioClient minioClient;

    public BlobStorageContext(ILogger<BlobStorageContext> logger, IConfiguration configuration)
    {
        _logger = logger;
        
        BlobStorageConfiguration config = configuration.GetSection("BlobStorageConfiguration")
            .Get<BlobStorageConfiguration>();
        try
        {
            /*minioClient = new MinioClient(config.Endpoint,
                config.AccessKey,
                config.SecretKey
            );*/ //.WithSSL();
            minioClient = new MinioClient()
                .WithEndpoint(config.Endpoint)
                .WithCredentials(config.AccessKey,
                    config.SecretKey)
                // .WithSSL()
                .Build();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        } 
        
    }
    
    public async Task AddDocument(string bucketName, string fileName, Stream fileStream)
    {
        // throw new System.NotImplementedException();
         var found = !await minioClient.BucketExistsAsync(bucketName);
         if (found)
         {
             await minioClient.MakeBucketAsync(bucketName);
         }

         try
        {
            // MemoryStream memoryStream = new MemoryStream();

            // await fileStream.CopyToAsync(memoryStream);
            
            // byte[] bs = await File.ReadAllBytesAsync("/home/dennis/testdisk.log");
            // System.IO.MemoryStream filestream = new System.IO.MemoryStream(bs);
            // Specify SSE-C encryption options
            // Aes aesEncryption = Aes.Create();
            // aesEncryption.KeySize = 256;
            // aesEncryption.GenerateKey();
            // var ssec = new SSEC(aesEncryption.Key);
            try
            {
                _logger.LogInformation("Fileupload: "+fileName + " " +fileStream);
                await minioClient.PutObjectAsync(bucketName,
                    fileName,
                    fileStream,
                    fileStream.Length,
                    "application/octet-stream"
                    // sse: ssec
                );
                
            }
            catch (Exception e)
            {
                _logger.LogCritical("Error occurred "+e.GetType());
                _logger.LogCritical(e.Message);
                _logger.LogCritical(e.StackTrace);
            }
            
            
            /* await minioClient.PutObjectAsync("test",
                "4hours.pdf",
                filestream,
                filestream.Length,
                "application/octet-stream"
                // sse: ssec
            );*/
            // Console.WriteLine("island.jpg is uploaded successfully");
        }
        catch(MinioException e)
        {
            Console.WriteLine("Error occurred: " + e);
            _logger.LogCritical("Minio Error " +e.Response);
        }
         _logger.LogInformation("End Blobstorage");
    }

    public async Task<Stream> GetFile(string bucketName, string fileName)
    {
        var memoryStream = new MemoryStream();
        await minioClient.GetObjectAsync(bucketName, fileName,
            (stream) =>
            {
                stream.CopyTo(memoryStream);
            });

        memoryStream.Position = 0;

        return memoryStream;
    }

    public Task<Stream> GetFile(string filePath)
    {
        var split = filePath.Split("/");
        return GetFile(split[0], split[1]);
    }
}
