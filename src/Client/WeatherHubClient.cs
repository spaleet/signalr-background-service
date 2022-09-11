using Microsoft.AspNetCore.SignalR.Client;

namespace Web.HubClients;

public class WeatherHubClient : IHostedService
{
    private readonly ILogger<WeatherHubClient> _logger;
    private HubConnection _connection;
    private const string HubUrl = "https://localhost:6100/hubs/weather";

    public WeatherHubClient(ILogger<WeatherHubClient> logger)
    {
        _logger = logger;

        _connection = new HubConnectionBuilder()
            .WithUrl(HubUrl)
            .Build();

        _connection.On<string>("ShowWeather", ShowWeather);
    }

    public Task ShowWeather(string weather)
    {
        _logger.LogInformation("{time} Received weather information : {weather}", DateTime.Now.ToString("g"), weather);

        return Task.CompletedTask;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            try
            {
                _logger.LogInformation("Connecting to hub ...");

                await _connection.StartAsync(cancellationToken);

                break;
            }
            catch
            {
                _logger.LogInformation("Connection failed. Reconnecting ...");
                await Task.Delay(1000, cancellationToken);
            }
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _connection.DisposeAsync();
    }
}
