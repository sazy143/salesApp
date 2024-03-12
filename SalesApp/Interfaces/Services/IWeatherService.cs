using SalesApp.Models;

namespace SalesApp.Interfaces.Services;

public interface IWeatherService
{
    public WeatherForecastDto[] GetWeather();
}