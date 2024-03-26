namespace SalesApp.Models.DB;

public class Account
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AccountExecutiveId { get; set; }
    public AccountExecutive AccountExecutive { get; set; } = null!;
    public long? SolutionEngineerId { get; set; }
    public SolutionEngineer? SolutionEngineer { get; set; }
    public ICollection<AccountProduct> AccountProducts { get; } = new List<AccountProduct>();
    public ICollection<SOW> Sows { get; } = new List<SOW>();
}