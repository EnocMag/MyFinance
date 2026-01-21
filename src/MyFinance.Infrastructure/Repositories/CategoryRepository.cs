using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;
using MySqlX.XDevAPI.Common;

namespace MyFinance.Infrastructure.Repositories;

public class CategoryRepository(MyFinanceDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<bool> NameExistsAsync(string name)
    {
        return await context.Categories
            .AnyAsync(c => c.Name == name);
    }
}
