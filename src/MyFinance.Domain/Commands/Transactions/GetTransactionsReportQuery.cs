using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Repositories;

namespace MyFinance.Domain.Commands.Transactions;

public class GetTransactionsReportQuery : IRequest<Result<IEnumerable<MonthlyReportDto>>>
{
    public TransactionType type { get; set; }
    public int Year { get; set; }
}

public class GetTransactionsReportQueryHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionsReportQuery, Result<IEnumerable<MonthlyReportDto>>>
{
    public async Task<Result<IEnumerable<MonthlyReportDto>>> Handle(GetTransactionsReportQuery request, CancellationToken cancellationToken)
    {
        var report = await transactionRepository.GetReportForMonth(request.type, request.Year);
        return Result<IEnumerable<MonthlyReportDto>>.Ok("Report retrived successfully.", report);
    }
}