using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesApp.Contexts;
using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;
using SalesApp.Repositories;
using SalesApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SalesAppContext>();

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<AccountExecutiveRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/weatherforecast", ([FromServices] IWeatherService weatherService) => weatherService.GetWeather())
    .WithName("GetWeatherForecast")
    .WithOpenApi(generatedOption =>
    {
        generatedOption.Description = "Hi there";
        return generatedOption;
    });

app.MapPost("/AE",
        async ([FromServices] AccountExecutiveRepository accountExecutiveRepository,
            [FromBodyAttribute] AccountExecutive ae) => await accountExecutiveRepository.CreateAccountExecutive(ae))
    .WithOpenApi();

app.MapGet("/AE",
    async ([FromServices] AccountExecutiveRepository accountExecutiveRepository) =>
    await accountExecutiveRepository.GetAccountExecutives()).WithOpenApi();

Console.WriteLine("Im here please log");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SalesAppContext>();
    Console.Write("Find migrations");
    if (context.Database.GetPendingMigrations().Any())
    {
        Console.Write("Found migrations");
        context.Database.Migrate();
    }
}

app.Run();