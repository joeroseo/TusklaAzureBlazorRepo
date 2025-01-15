using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Shared.Models;

namespace MyNamespace
{
    public static class ProductFunction2
    {
        [FunctionName("GetProducts2")]
        public static HttpResponseMessage GetProducts2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product3")] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("Test response for GetProducts function2.");

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