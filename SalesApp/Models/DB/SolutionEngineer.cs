namespace SalesApp.Models.DB;

public class SolutionEngineer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Account> Accounts { get; } = new List<Account>();
};