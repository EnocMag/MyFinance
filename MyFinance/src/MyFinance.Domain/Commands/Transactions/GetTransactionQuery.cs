using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;

namespace MyFinance.Domain.Commands.Transactions;

public class GetTransactionQuery : IRequest<Result<Transaction>>
{
    public int Id { get; set; }
}

public class GetTransactionQueryHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionQuery, Result<Transaction>>
{
    public async Task<Result<Transaction>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var transaction = await transactionRepository.GetByIdAsync(request.Id);
        if (transaction == null)
        {
            return Result<Transaction>.Fail("Transaction not found", System.Net.HttpStatusCode.NotFound);
        }
        return Result<Transaction>.Ok("Transaction retrieved successfully", transaction);
    }
}