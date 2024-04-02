using SalesApp.Models.Enums;

namespace SalesApp.Models.DB;

public class User {
    public long Id {get; set;}
    public required string Name {get; set;}
    public required string Email {get; set;}
    public required string Password {get; set;}
    public required UserType UserType {get; set;}
}