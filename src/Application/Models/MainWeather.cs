namespace Application.Models;

public class MainWeather
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("pressure")]
    public double Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public long Humidity { get; set; }

    [JsonPropertyName("temp_min")]
    public double TemperatureMin { get; set; }

    [JsonPropertyName("temp_max")]
    public double TemperatureMax { get; set; }

    [JsonIgnore]
    public double CelsiusCurrent
    {
        get
        {
            return ConvertToCelsius(Temperature);
        }
    }

    [JsonIgnore]
    public double FahrenheitCurrent
    {
        get
        {
            return ConvertToFahrenheit(CelsiusCurrent);
        }
    }

    private static double ConvertToFahrenheit(double celsius)
    {
        return Math.Round(((9.0 / 5.0) * celsius) + 32, 3);
    }

    private static double ConvertToCelsius(double kelvin)
    {
        return Math.Round(kelvin - 273.15, 3);
    }
}
