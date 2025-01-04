using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TusklaBlazor.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using TusklaBlazor.Shared.Models;
using TusklaBlazor.Client.Services;
using TusklaBlazor.Shared.Services;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Set the root component for the Blazor WebAssembly app
builder.RootComponents.Add<App>("#app");

// Register the Blazored.LocalStorage service for local storage support
builder.Services.AddBlazoredLocalStorage();

// Register HttpClient using the default configuration (it will use relative URLs)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register your custom services
builder.Services.AddScoped<IItemListService, ItemListService>();  // Example service
builder.Services.AddScoped<CartService>();  // Example service for cart management

// Add other services as needed (authentication, etc.)
// builder.Services.AddScoped<IYourOtherService, YourOtherService>();

// No authentication setup (as per your current requirements)

await builder.Build().RunAsync();
