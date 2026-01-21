using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;

namespace MyFinance.Infrastructure.Repositories;

public class CategoryRepository(MyFinanceDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
}
