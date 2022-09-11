using Application.Settings;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Application.Services;

public interface IWeatherClient
{
    Task<Weather?> GetWeatherAsync(string city, string unit = "metric");
}

public class WeatherClient : IWeatherClient
{
    private readonly WeatherSettings _settings;
    private readonly HttpClient _client;

    public WeatherClient(IOptions<WeatherSettings> weatherSettings, HttpClient client)
    {
        _settings = weatherSettings.Value;
        _client = client;
    }

    public async Task<Weather?> GetWeatherAsync(string city, string unit = "metric")
    {
        if (string.IsNullOrEmpty(city))
            throw new ArgumentNullException(nameof(city));

        var query = new Dictionary<string, string>()
        {
            ["q"] = city,
            ["appid"] = _settings.ApiKey,
            ["lang"] = "en",
            ["unit"] = unit,
        };

        string uri = QueryHelpers.AddQueryString("weather", query);

        var res = await _client.GetAsync(uri);
        res.EnsureSuccessStatusCode();

        string content = await res.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Weather>(content);
    }
}
