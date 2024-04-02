using SalesApp.Models.DB;
using SalesApp.Models.DTOs;

namespace SalesApp.Interfaces.Services;

public interface IUserService
{
    public Task<User> CreateUser(RegisterDto user);
    public User GetUserByEmail(string email);
}