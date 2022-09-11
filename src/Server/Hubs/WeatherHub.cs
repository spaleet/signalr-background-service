using Microsoft.AspNetCore.SignalR;

namespace Web.Hubs;

public class WeatherHub : Hub<IWeatherHub>
{
    private readonly IWeatherClient _weatherClient;
    private readonly ILogger<WeatherHub> _logger;

    public WeatherHub(IWeatherClient weatherClient, ILogger<WeatherHub> logger)
    {
        _logger = logger;
        _weatherClient = weatherClient;
    }

    public async Task SendWeather()
    {
        string city = "chicago";

        var weatherData = await _weatherClient.GetWeatherAsync(city);
        string weatherMessage = string.Format("The temperature in {0}, {1} is currently {2} °C", city, weatherData?.SystemWeather.Country, weatherData?.Main.CelsiusCurrent);

        _logger.LogInformation("Sent weather data for {city} to client", city);
        await Clients.All.ShowWeather(weatherMessage);
    }
}
