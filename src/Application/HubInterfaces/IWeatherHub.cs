namespace Application.HubInterfaces;

public interface IWeatherHub
{
    Task ShowWeather(string weatherMessage);
}
