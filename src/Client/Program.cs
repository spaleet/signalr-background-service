using Serilog;
using Web.HubClients;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, lc) => lc.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHostedService<WeatherHubClient>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

Log.Information("Application Starting ...");
await app.RunAsync();
