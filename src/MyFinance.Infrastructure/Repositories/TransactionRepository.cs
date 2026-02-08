using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Repositories;
using MyFinance.Infrastructure.DbContexts;

namespace MyFinance.Infrastructure.Repositories;

public class TransactionRepository(MyFinanceDbContext context) : BaseRepository<Transaction>(context), ITransactionRepository
{
    public async Task<decimal> GetTotalByPeriodAndType(DateTime startDate, DateTime endDate, TransactionType type)
    {
        return await context.Transactions
            .Where(x => x.Date >= startDate && x.Date <= endDate && x.Type == type)
            .SumAsync(v => v.Amount);
    }

    public async Task<IEnumerable<MonthlyReportDto>> GetReportForMonth(TransactionType type, int year)
    {
        return await context.Transactions
            .Where(x => x.Type == type && x.Date.Year == year)
            .GroupBy(x => x.Date.Month)
            .OrderBy(g => g.Key)
            .Select(g => new MonthlyReportDto
            {
                Month = g.Key,
                Total = g.Sum(x => x.Amount)
            })
            .ToListAsync();
    }
}
