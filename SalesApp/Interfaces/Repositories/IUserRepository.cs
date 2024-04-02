using SalesApp.Models.DB;

namespace SalesApp.Interfaces.Repositories;
public interface IUserRepository{
    public Task<User> CreateUser(User user);
    public User? GetUserByEmail(string email);
}