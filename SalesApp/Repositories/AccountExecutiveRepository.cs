using Microsoft.EntityFrameworkCore;
using SalesApp.Contexts;
using SalesApp.Models.DB;

namespace SalesApp.Repositories;

public class AccountExecutiveRepository
{
    private readonly SalesAppContext _dbContext = new();

    public async Task<AccountExecutive> CreateAccountExecutive(AccountExecutive accountExecutive)
    {
        _dbContext.AccountExecutives.Add(accountExecutive);
        await _dbContext.SaveChangesAsync();
        return accountExecutive;
    }

    public async Task<ICollection<AccountExecutive>> GetAccountExecutives()
    {
        return await _dbContext.AccountExecutives.ToListAsync();
    }
}