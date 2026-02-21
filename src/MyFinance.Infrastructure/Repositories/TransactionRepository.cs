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
            .Where(t => t.Type == type && t.Date.Year == year)
            .GroupBy(t => new { t.Date.Year, t.Date.Month })
            .OrderBy(g => new { g.Key.Year, g.Key.Month })
            .Select(g => new MonthlyReportDto
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Total = g.Sum(x => x.Amount)
            }).ToListAsync();

    }
}
