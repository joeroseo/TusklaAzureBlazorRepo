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

public static class ProductFunction
{
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");

    [FunctionName("GetProducts")]
    // Updated authorization level to Anonymous for no authentication required
    public static async Task<HttpResponseMessage> GetProducts(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product")] HttpRequestMessage req,
        ILogger log)
    {
        log.LogInformation("Fetching product data.");

        if (string.IsNullOrEmpty(ConnectionString))
        {
            log.LogError("Connection string is not configured.");
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Database connection string is not configured.")
            };
        }

        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer(ConnectionString, options =>
            options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null)); // Enable retry on failure with 5 attempts and 10-second delay

        try
        {
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                List<Product> products = await context.Products.ToListAsync();

                var responseContent = JsonSerializer.Serialize(products, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseContent, System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
        catch (Exception ex)
        {
            log.LogError($"Error fetching products: {ex.Message}");
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent($"An error occurred while fetching products: {ex.Message}")
            };
        }
    }
}
