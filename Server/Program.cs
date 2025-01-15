using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TusklaBlazor.Server.Data;
using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Server.Services;
using TusklaBlazor.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(connectionString)); // Add DatabaseContext to services

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Retry up to 5 times
            maxRetryDelay: TimeSpan.FromSeconds(200), // Wait 200 seconds between retries
            errorNumbersToAdd: null); // Optional: Specify SQL error codes to retry
    }));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("https://orange-hill-09ac8731e.4.azurestaticapps.net/api/") 
});

// CORS configuration: Allowing all origins (for development only; for production, be specific)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allow all origins (be specific in production)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add the other services
builder.Services.AddTransient<IVehicleOrderInfo, VehicleOrderInfoManager>();
builder.Services.AddTransient<IVehicleOrderItems, VehicleOrderItemsManager>();
builder.Services.AddTransient<IProductOrderInfo, ProductOrderInfoManager>();
builder.Services.AddTransient<IProductOrderItems, ProductOrderItemsManager>();
builder.Services.AddTransient<IProductManager, ProductManager>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // We do NOT need Browser Link in development anymore
    // Disable Browser Link explicitly if there is any (though it seems to be disabled already)
    // app.UseBrowserLink(); // Ensure this is not being called elsewhere

    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging(); // Only in development
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable CORS middleware (add this line to support cross-origin requests)
app.UseCors("AllowAll");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// Map API controllers (make sure these are set up in your project)
app.MapControllers(); // Maps API controllers to /api routes
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
