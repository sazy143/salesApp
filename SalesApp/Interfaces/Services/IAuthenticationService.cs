using SalesApp.Models.DTOs;

namespace SalesApp.Interfaces.Services;

public interface IAuthenticationService
{
    Task<string> RegisterUser(RegisterDto user);
    Task<string> Login(LoginDto login);
}