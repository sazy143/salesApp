using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;
using SalesApp.Models.DTOs;

namespace SalesApp.Services;

public class AuthenticationService(IUserService userService, IConfiguration configuration) : IAuthenticationService
{
    public async Task<string> RegisterUser(RegisterDto user)
    {
        var createdUser = await userService.CreateUser(user);
        return CreateToken(createdUser);
    }

    public async Task<string> Login(LoginDto login)
    {
        try
        {
            var user = userService.GetUserByEmail(login.Email);
            if (user.Password.Equals(login.Password)) return CreateToken(user);

            throw new InvalidCredentialException();
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync(e.Message);
            return "";
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims =
        [
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.Name),
            new Claim("Role", user.UserType.ToString())
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWTKey").Value!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}