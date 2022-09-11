namespace Application.Models;

public class Weather
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("dt")]
    public long UnixDateTime { get; set; }

    [JsonIgnore]
    public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(UnixDateTime).DateTime;

    [JsonPropertyName("main")]
    public MainWeather Main { get; set; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [JsonPropertyName("weather")]
    public IEnumerable<State> State { get; set; }

    [JsonPropertyName("visibility")]
    public double Visibility { get; set; }

    [JsonPropertyName("sys")]
    public SystemWeather SystemWeather { get; set; }
}
