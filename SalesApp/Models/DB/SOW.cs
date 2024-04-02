namespace SalesApp.Models.DB;

public class SOW
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public ICollection<SOWProduct> SowProducts { get; } = [];
}