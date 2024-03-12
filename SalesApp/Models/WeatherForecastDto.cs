namespace SalesApp.Models;

public class WeatherForecastDto(DateOnly date, int temperatureC, string? summary)
{
    public DateOnly Date = date;
    public string? Summary = summary;
    public int TemperatureF => 32 + (int) (temperatureC / 0.5556);

}