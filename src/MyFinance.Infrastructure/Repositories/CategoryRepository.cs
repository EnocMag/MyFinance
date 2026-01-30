using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;

namespace MyFinance.Infrastructure.Repositories;

public class CategoryRepository(MyFinanceDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<bool> NameExistsAsync(string name)
    {
        return await context.Categories
            .AnyAsync(c => c.Name == name);
    }
    public async Task<IEnumerable<Category>> GetByTypeAsync(TransactionType type)
    {
        return await context.Categories.Where(c => c.Type == type).ToListAsync();
    }
}
