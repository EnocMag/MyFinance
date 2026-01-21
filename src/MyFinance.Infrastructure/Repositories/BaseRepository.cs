using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;

namespace MyFinance.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(
    MyFinanceDbContext context
    ) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
    public async Task AddAsync(TEntity obj, bool saveChanges = true)
    {
        await context.AddAsync(obj);
        if (saveChanges)
            await context.SaveChangesAsync();
    }
    public async Task Update(TEntity obj, bool saveChanges = true)
    {
        context.Update(obj);
        if (saveChanges)
            await context.SaveChangesAsync();
    }
    public async Task Delete(TEntity obj, bool saveChages = true)
    {
        context.Remove(obj);
        if (saveChages)
            await context.SaveChangesAsync();
    }
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
