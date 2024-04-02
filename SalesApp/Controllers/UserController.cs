namespace SalesApp.Controllers;
public static class UserController{

    public static void Map(WebApplication app){
        app.MapPost("/user/register", () => {

        });
    }
}