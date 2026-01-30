using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;

namespace MyFinance.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> NameExistsAsync(string name);
    Task<IEnumerable<Category>> GetByTypeAsync(TransactionType type);
}
