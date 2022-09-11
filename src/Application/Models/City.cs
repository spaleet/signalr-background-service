namespace Application.Models;

public class City
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
