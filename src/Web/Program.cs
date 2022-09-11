using Application.Services;
using Application.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

builder.Services.Configure<WeatherSettings>(builder.Configuration.GetSection("WeatherSettings"));
builder.Services.AddHttpClient<IWeatherClient, WeatherClient>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["WeatherSettings:BaseUrl"]);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
