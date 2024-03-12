using SalesApp.Interfaces.Services;
using SalesApp.Models;

namespace SalesApp.Services;

public class WeatherService : IWeatherService {
    readonly string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public WeatherForecastDto[] GetWeather()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastDto
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
            .ToArray();
        return forecast;
    }
}

