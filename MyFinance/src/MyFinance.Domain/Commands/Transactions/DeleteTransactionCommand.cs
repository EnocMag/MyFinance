using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Transactions;

public class DeleteTransactionCommand : IRequest<Result<Transaction>>
{
    public int Id { get; set; }
}

public class DeleteTransactionCommandHandler(ITransactionService transactionService) : IRequestHandler<DeleteTransactionCommand, Result<Transaction>>
{
    public async Task<Result<Transaction>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        return await transactionService.DeleteTransaction(request.Id);
    }
}