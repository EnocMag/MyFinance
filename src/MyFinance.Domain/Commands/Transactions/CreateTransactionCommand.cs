using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Transactions;

public class CreateTransactionCommand : IRequest<Result<Transaction>>
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
}

public class CreateTransactionCommandHandler(ITransactionService transactionService) : IRequestHandler<CreateTransactionCommand, Result<Transaction>>
{
    public async Task<Result<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        return await transactionService.CreateTransactionAsync(request);
    }
}