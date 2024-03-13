using SalesApp.Services;

namespace SalesAppTests;

public class Tests
{
    WeatherService weatherService;
    [SetUp]
    public void Setup()
    {
        weatherService = new WeatherService();
    }

    [Test]
    public void WeatherServiceReturns5()
    {
        var expectedCount = 5;
        var weathers = weatherService.GetWeather();

        Assert.That(weathers, Has.Length.EqualTo(expectedCount));
    }
}