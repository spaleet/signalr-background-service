using Application.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

builder.Host.UseSerilog((context, lc) => lc.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<WeatherSettings>(builder.Configuration.GetSection("WeatherSettings"));
builder.Services.AddHttpClient<IWeatherClient, WeatherClient>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["WeatherSettings:BaseUrl"]);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
