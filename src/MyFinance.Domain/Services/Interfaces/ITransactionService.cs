using MyFinance.Domain.Commands.Transactions;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;

namespace MyFinance.Domain.Services.Interfaces;

public interface ITransactionService
{
    Task<Result<Transaction>> CreateTransaction(CreateTransactionCommand input);
    Task<Result<Transaction>> UpdateTransaction(UpdateTransactionCommand input);
    Task<Result<Transaction>> DeleteTransaction(int id);
}
