namespace Application.Models;

public class SystemWeather
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("sunrise")]
    public long Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; set; }

    [JsonIgnore]
    public DateTime SunriseDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunrise).DateTime;

    [JsonIgnore]
    public DateTime SunsetDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunset).DateTime;
}
