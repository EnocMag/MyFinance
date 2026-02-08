using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Enums;

namespace MyFinance.Domain.Repositories;

public interface ITransactionRepository : IBaseRepository<Entities.Transaction>
{
    Task<IEnumerable<MonthlyReportDto>> GetReportForMonth(TransactionType type, int year);
}
