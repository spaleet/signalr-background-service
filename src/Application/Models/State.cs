namespace Application.Models;

public class State
{
    [JsonPropertyName("main")]
    public string MainWeather { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    private string _icon = string.Empty;
    [JsonPropertyName("icon")]
    public string Icon
    {
        get => $"https://openweathermap.org/img/w/{_icon}.png";
        set => _icon = value;
    }
}
