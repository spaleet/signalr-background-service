using Application.Settings;
using Serilog;
using Server.Workers;
using Web.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

builder.Host.UseSerilog((context, lc) => lc.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<WeatherSettings>(builder.Configuration.GetSection("WeatherSettings"));
builder.Services.AddHttpClient<IWeatherClient, WeatherClient>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["WeatherSettings:BaseUrl"]);
});
builder.Services.AddSignalR();
builder.Services.AddHostedService<WeatherWorker>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<WeatherHub>("/hubs/weather");

app.Run();
