using SalesApp.Interfaces.Services;
using SalesApp.Models.DB;

namespace SalesApp.Services;

public class AuthenticationService(IUserService userService){

    public async Task<string> RegisterUser(User user){
        var createdUser = await userService.CreateUser(user);
    }
}