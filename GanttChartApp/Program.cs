using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GanttChartApp.Components;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Set the root component
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add HTTP client for API calls (if needed)
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Syncfusion Blazor service
// Licensed Syncfusion NuGet packages are restored from the GitHub Packages feed (see nuget.config)
builder.Services.AddSyncfusionBlazor();

var host = builder.Build();

await host.RunAsync();
