using MyFinance.Domain.Commands.Transactions;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;

namespace MyFinance.Domain.Services.Interfaces;

public interface ITransactionService
{
    Task<Result<Transaction>> CreateTransactionAsync(CreateTransactionCommand input);
    Task<Result<Transaction>> UpdateTransactionAsync(UpdateTransactionCommand input);
    Task<Result<Transaction>> DeleteTransactionAsync(int id);
}
