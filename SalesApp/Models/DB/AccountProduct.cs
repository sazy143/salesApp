namespace SalesApp.Models.DB;

public class AccountProduct
{
    public long Id { get; set; }
    public string? Properties { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public long AccountId { get; set; }
    public Account Account { get; set; } = null!;
}