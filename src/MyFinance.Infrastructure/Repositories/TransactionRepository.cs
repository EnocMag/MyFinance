using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;

namespace MyFinance.Infrastructure.Repositories;

public class TransactionRepository(MyFinanceDbContext context) : BaseRepository<Transaction>(context), ITransactionRepository
{

}
