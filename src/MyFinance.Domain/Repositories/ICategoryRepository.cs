using MyFinance.Domain.Entities;

namespace MyFinance.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> NameExistsAsync(string name);
}
