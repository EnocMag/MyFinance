using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Transactions;

public class UpdateTransactionCommand : IRequest<Result<Transaction>>
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Amount { get; set; }
    public TransactionType? Type { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
}

public class UpdateTransactionCommandHandler(ITransactionService transactionService) : IRequestHandler<UpdateTransactionCommand, Result<Transaction>>
{
    public async Task<Result<Transaction>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return Result<Transaction>.Fail("Id must be greater than zero.");
        return await transactionService.UpdateTransactionAsync(request);
    }
}