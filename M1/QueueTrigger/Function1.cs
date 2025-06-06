using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using Microsoft.Azure.Functions.Worker;

namespace MoviePosterFunction
{
    public class Function1
    {
        private readonly HttpClient _httpClient;
        private readonly IDatabase _redisDb;

        private readonly string _omdbApiKey = Environment.GetEnvironmentVariable("OMDB_API_KEY");

        public Function1(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

            var redisConnection = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
            var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnection);
            _redisDb = connectionMultiplexer.GetDatabase();
        }

        [Function("MoviePosterQueueTrigger")]
        public async Task Run(
            [QueueTrigger("moviesqueue", Connection = "AzureWebJobsStorage")] string movieName,
            ILogger log)
        {
            log.LogInformation($"Queue-dan '{movieName}' adlı kino alındı.");

           
            var requestUrl = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(movieName)}&apikey={_omdbApiKey}";

            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                log.LogError($"OMDB API Error: {response.StatusCode}");
                return;
            }

            var content = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(content);

            if (jsonDoc.RootElement.TryGetProperty("Poster", out var posterElement))
            {
                var posterUrl = posterElement.GetString();

                if (!string.IsNullOrEmpty(posterUrl) && posterUrl != "N/A")
                {
                    await _redisDb.StringSetAsync(movieName, posterUrl);
                    log.LogInformation($"Poster Redis-ə yazıldı: {movieName} -> {posterUrl}");
                }
                else
                {
                    log.LogWarning($"Poster tapılmadı: {movieName}");
                }
            }
            else
            {
                log.LogWarning($"Poster field mövcud deyil: {movieName}");
            }
        }
    }
}
