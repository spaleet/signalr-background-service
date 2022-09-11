namespace Application.Settings;

public class WeatherSettings
{
    /// <summary>
    /// Key of application openweathermap
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Base url of api openweathermap
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;
}
