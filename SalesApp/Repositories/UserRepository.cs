using SalesApp.Contexts;
using SalesApp.Interfaces.Repositories;
using SalesApp.Models.DB;

namespace SalesApp.Repositories;
public class UserRepository : IUserRepository {
    
    private readonly SalesAppContext _dbContext = new();

    public async Task<User> CreateUser(User user){
         _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public User? GetUserByEmail(string email){
        return _dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
    }
}