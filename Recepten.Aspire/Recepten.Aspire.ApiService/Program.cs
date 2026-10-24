using Microsoft.EntityFrameworkCore;
using Recepten.Aspire.ApiService.Data;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
static void ConfigureServices(WebApplicationBuilder builder)
{
#pragma warning disable CA1416
    builder.Services.AddDbContext<BomDbContext>(options =>
    {
        options.UseJet(builder.Configuration.GetConnectionString("Default"));
    });
#pragma warning restore CA416    
}

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Database connection - to be reviewed

if (OperatingSystem.IsWindows())
{
    ConfigureServices(builder);
}
builder.Services.AddControllers();
// build http services
builder.Services.AddHttpClient("ApiServices");
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/", () => "API service is running. Navigate to /weatherforecast to see sample data.");

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.MapControllers();
app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

