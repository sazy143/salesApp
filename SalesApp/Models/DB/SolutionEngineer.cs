namespace SalesApp.Models.DB;

public class SolutionEngineer
{
    public long Id { get; set; }
    public long UserId {get; set;}
    public User User {get; set;} = null!;
    public ICollection<Account> Accounts { get; } = [];
};