namespace SalesApp.Models.DB;

public class SOWProduct
{
    public long Id { get; set; }
    public string? Properties { get; set; }
    public decimal Discount { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public long SowId { get; set; }
    public SOW Sow { get; set; } = null!;
}