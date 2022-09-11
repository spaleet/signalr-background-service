using Microsoft.AspNetCore.SignalR;
using Web.Hubs;

namespace Server.Workers;

public class WeatherWorker : BackgroundService
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(60));
    private readonly IWeatherClient _weatherClient;
    private readonly ILogger<WeatherWorker> _logger;
    private readonly IHubContext<WeatherHub> _hub;

    public WeatherWorker(ILogger<WeatherWorker> logger, IWeatherClient weatherClient, IHubContext<WeatherHub> hub)
    {
        _logger = logger;
        _hub = hub;
        _weatherClient = weatherClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {Time}", DateTime.Now);

        while (await _timer.WaitForNextTickAsync(stoppingToken)
                && !stoppingToken.IsCancellationRequested)
        {
            string city = "chicago";

            var weatherData = await _weatherClient.GetWeatherAsync(city);
            string weatherMessage = string.Format("The temperature in {0}, {1} is currently {2} °C", city, weatherData?.SystemWeather.Country, weatherData?.Main.CelsiusCurrent);

            _logger.LogInformation("Sent weather data for {city} to client", city);
            await _hub.Clients.All.SendAsync("ShowWeather", weatherMessage);
        }
    }
}