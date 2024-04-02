using SalesApp.Interfaces.Services;
using SalesApp.Models.DTOs;

namespace SalesApp.Controllers;

public static class AuthenticationController
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/auth/register", (IAuthenticationService authenticationService, RegisterDto user) =>
        {
            return authenticationService.RegisterUser(user);
        })
        .WithOpenApi()
        .Produces<string>();

        app.MapPost("/auth/login", (IAuthenticationService authenticationService, LoginDto login) =>
        {
            return authenticationService.Login(login);
        })
        .WithOpenApi()
        .Produces<string>();;
    }
}