using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public static class ProductFunction
    {
        [FunctionName("GetProducts2")]
        public static HttpResponseMessage GetProducts2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product2")] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("Test response for GetProducts2 function.");

            // Return a simple test response
            var testProducts = new[]
            {
                new { Id = 1, Name = "Product A", Price = 9.99 },
                new { Id = 2, Name = "Product B", Price = 19.99 }
            };

            var responseContent = JsonSerializer.Serialize(testProducts, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
