using SalesApp.Interfaces.Repositories;
using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;

namespace SalesApp.Services;

public class UserService(IUserRepository userRepository) : IUserService{

    public User? GetUserByEmail(string email)
    {
        return userRepository.GetUserByEmail(email);
    }

    async Task<User> IUserService.CreateUser(User user)
    {
        return await userRepository.CreateUser(user);
    }
}