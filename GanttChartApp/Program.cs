using GanttChartApp.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure circuit options for detailed errors in development
builder.Services.Configure<Microsoft.AspNetCore.Components.Server.CircuitOptions>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.DetailedErrors = true;
    }
});

// Add Syncfusion Blazor service and export services
builder.Services.AddSyncfusionBlazor();
builder.Services.AddMemoryCache();

// Get Syncfusion license key from environment variable (for GitHub Actions) or user secrets (for local development)
var syncfusionLicenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY") 
                          ?? builder.Configuration["Syncfusion:LicenseKey"];

if (!string.IsNullOrEmpty(syncfusionLicenseKey))
{
    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionLicenseKey);
    Console.WriteLine("Syncfusion license key registered successfully");
}
else if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("Warning: Syncfusion license key not found in environment variables or user secrets");
}
else
{
    Console.WriteLine("Warning: Syncfusion license key not configured. Some features may not work properly.");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
