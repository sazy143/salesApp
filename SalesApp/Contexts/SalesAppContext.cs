using Microsoft.EntityFrameworkCore;
using SalesApp.Models.DB;

namespace SalesApp.Contexts;

public class SalesAppContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountExecutive> AccountExecutives { get; set; }
    public DbSet<AccountProduct> AccountProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SolutionEngineer> SolutionEngineers { get; set; }
    public DbSet<SOW> Sows { get; set; }
    public DbSet<SOWProduct> SowProducts { get; set; }
    
    public string DbPath { get; }
    
    public SalesAppContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "salesApp.db");
        Console.Write("Path: " + DbPath);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}