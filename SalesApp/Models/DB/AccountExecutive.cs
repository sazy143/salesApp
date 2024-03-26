namespace SalesApp.Models.DB;

public class AccountExecutive
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Account> Accounts { get; } = new List<Account>();
}