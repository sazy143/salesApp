namespace SalesApp.Models;

public class WeatherForecastDto(DateOnly date, int temperatureC, string? summary)
{
    public DateOnly Date => date;
    public string? Summary => summary;
    public int TemperatureC => temperatureC;
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}