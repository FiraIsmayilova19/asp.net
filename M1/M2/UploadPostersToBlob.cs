using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;

namespace M2PosterUploader
{
    public class UploadPostersToBlob
    {
        private readonly IDatabase _redisDb;
        private readonly BlobContainerClient _blobContainer;

        public UploadPostersToBlob()
        {
            var redisConn = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
            var redis = ConnectionMultiplexer.Connect(redisConn);
            _redisDb = redis.GetDatabase();

            var blobConn = Environment.GetEnvironmentVariable("BLOB_CONNECTION");
            _blobContainer = new BlobContainerClient(blobConn, "posters");
            _blobContainer.CreateIfNotExists();
        }

        [Function("UploadPostersToBlob")]
        public async Task Run([TimerTrigger("*/30 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Timer function işə düşdü: {DateTime.Now}");

            var server = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_CONNECTION")).GetServer(Environment.GetEnvironmentVariable("REDIS_HOST"));
            var keys = server.Keys(pattern: "*");

            foreach (var key in keys)
            {
                var posterUrl = await _redisDb.StringGetAsync(key);
                if (string.IsNullOrEmpty(posterUrl))
                    continue;

                var blobName = $"{key.ToString().ToLower().Replace(" ", "_")}.txt";
                var blobClient = _blobContainer.GetBlobClient(blobName);

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(posterUrl));
                await blobClient.UploadAsync(stream, overwrite: true);

                log.LogInformation($"Yazıldı: {blobName}");

                await _redisDb.KeyDeleteAsync(key);
            }
        }
    }
}
