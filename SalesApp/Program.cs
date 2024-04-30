using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SalesApp.Contexts;
using SalesApp.Controllers;
using SalesApp.Interfaces.Repositories;
using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;
using SalesApp.Repositories;
using SalesApp.Services;
using IAuthenticationService = SalesApp.Interfaces.Services.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTKey").Value!))
    };
});
builder.Services.AddAuthorization();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

#region DI

#region Contexts

builder.Services.AddDbContext<SalesAppContext>();

#endregion

#region Services

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

#endregion

#region Repositories

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<AccountExecutiveRepository>();

#endregion

#endregion

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

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

app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Claims.First(x => x.Type.Equals("Name"))}. My secret")
    .RequireAuthorization();

AuthenticationController.Map(app);


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SalesAppContext>();
    if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
}

app.Run();