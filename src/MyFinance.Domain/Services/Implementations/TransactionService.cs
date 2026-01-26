using MyFinance.Domain.Commands.Transactions;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Interfaces;
using System.Net;

namespace MyFinance.Domain.Services.Implementations;

public class TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository) : ITransactionService
{
    public async Task<Result<Transaction>> CreateTransactionAsync(CreateTransactionCommand input)
    {
        var category = await categoryRepository.GetByIdAsync(input.CategoryId);
        if (category == null)
        {
            return Result<Transaction>.Fail("Category not found.", HttpStatusCode.NotFound);
        }
        if (category.Type != input.Type)
        {
            return Result<Transaction>.Fail("Category type does not match transaction type.", HttpStatusCode.BadRequest);
        }
        if (input.Amount <= 0)
        {
            return Result<Transaction>.Fail("Amount must be greater than zero.", HttpStatusCode.BadRequest);
        }
        var transaction = new Transaction
        {
            Date = input.Date,
            Amount = input.Amount,
            Type = input.Type,
            Description = input.Description,
            Category = category,
            CategoryNameSnapshot = category.Name,
            CreatedAt = DateTime.UtcNow,
        };

        await transactionRepository.AddAsync(transaction);
        return Result<Transaction>.Ok("Transaction created successfully.", transaction);
    }

    public async Task<Result<Transaction>> UpdateTransactionAsync(UpdateTransactionCommand imput)
    {
        var transaction = await transactionRepository.GetByIdAsync(imput.Id);
        if (transaction == null)
            return Result<Transaction>.Fail("Transaction not found.", HttpStatusCode.NotFound);

        if (imput.CategoryId.HasValue)
        {
            var category = await categoryRepository.GetByIdAsync(imput.CategoryId.Value);
            if (category == null)
            {
                return Result<Transaction>.Fail("Category not found.", HttpStatusCode.NotFound);
            }
            if (imput.Type.HasValue && category.Type != imput.Type.Value)
            {
                return Result<Transaction>.Fail("Category type does not match transaction type.", HttpStatusCode.BadRequest);
            }
            transaction.Category = category;
        }
            
        transaction.Date        = imput.Date        ?? transaction.Date;
        transaction.Amount      = imput.Amount      ?? transaction.Amount;
        transaction.Type        = imput.Type        ?? transaction.Type;
        transaction.Description = imput.Description ?? transaction.Description;
        transaction.UpdatedAt   = DateTime.UtcNow;

        await transactionRepository.Update(transaction);
        return Result<Transaction>.Ok("Transaction updated successfully.", transaction);
    }

    public async Task<Result<Transaction>> DeleteTransactionAsync(int id)
    {
        var transaction = await transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return Result<Transaction>.Fail("Transaction not found.", HttpStatusCode.NotFound);
        await transactionRepository.Delete(transaction);
        return Result<Transaction>.Ok("Transaction deleted successfully.");
    }
}
