using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;

namespace MyFinance.Domain.Commands.Transactions;

public class GetAllTransactionsQuery : IRequest<Result<IEnumerable<Transaction>>>
{
}

public class GetAllTransactionsQueryHandler(ITransactionRepository transactionService) : IRequestHandler<GetAllTransactionsQuery, Result<IEnumerable<Transaction>>>
{
    public async Task<Result<IEnumerable<Transaction>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await transactionService.GetAllAsync();
        if (transactions.Count() == 0)
            return Result<IEnumerable<Transaction>>.Fail("No transactions.", System.Net.HttpStatusCode.NotFound);
        return Result<IEnumerable<Transaction>>.Ok("Transactions retrieved successfully.", transactions);
    }
}
