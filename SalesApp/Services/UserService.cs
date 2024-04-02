using SalesApp.Interfaces.Repositories;
using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;
using SalesApp.Models.DTOs;

namespace SalesApp.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public User GetUserByEmail(string email)
    {
        return userRepository.GetUserByEmail(email);
    }

    async Task<User> IUserService.CreateUser(RegisterDto user)
    {
        var newUser = new User
        {
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            UserType = user.UserType
        };
        return await userRepository.CreateUser(newUser);
    }
}