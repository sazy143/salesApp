using SalesApp.Models.DB;

namespace SalesApp.Interfaces.Services;
public interface IUserService{
    public Task<User> CreateUser(User user);
    public User? GetUserByEmail(string email);
}