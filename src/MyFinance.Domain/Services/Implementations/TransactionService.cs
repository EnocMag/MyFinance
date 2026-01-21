using MyFinance.Domain.Commands.Transactions;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Interfaces;
using System.Net;

namespace MyFinance.Domain.Services.Implementations;

public class TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository) : ITransactionService
{
    public async Task<Result<Transaction>> CreateTransaction(CreateTransactionCommand input)
    {
        var category = await categoryRepository.GetByIdAsync(input.CategoryId);
        if (category == null)
        {
            return Result<Transaction>.Fail("Category not found", System.Net.HttpStatusCode.NotFound);
        }
        if (category.Type != input.Type)
        {
            return Result<Transaction>.Fail("Category type does not match transaction type", System.Net.HttpStatusCode.BadRequest);
        }
        if (input.Amount <= 0)
        {
            return Result<Transaction>.Fail("Amount must be greater than zero", System.Net.HttpStatusCode.BadRequest);
        }
        var transaction = new Transaction
        {
            Date = input.Date,
            Amount = input.Amount,
            Type = input.Type,
            Description = input.Description,
            Category = category,
            CreatedAt = DateTime.UtcNow,
        };
        await transactionRepository.AddAsync(transaction);
        return Result<Transaction>.Ok("Transaction created successfully", transaction);
    }

    public async Task<Result<Transaction>> UpdateTransaction(UpdateTransactionCommand imput)
    {
        var transaction = await transactionRepository.GetByIdAsync(imput.Id);
        if (transaction == null)
            return Result<Transaction>.Fail("Transaction not found", HttpStatusCode.NotFound);

        if (imput.CategoryId.HasValue)
        {
            var category = await categoryRepository.GetByIdAsync(imput.CategoryId.Value);
            if (category == null)
            {
                return Result<Transaction>.Fail("Category not found", HttpStatusCode.NotFound);
            }
            if (imput.Type.HasValue && category.Type != imput.Type.Value)
            {
                return Result<Transaction>.Fail("Category type does not match transaction type", HttpStatusCode.BadRequest);
            }
            transaction.Category = category;
        }
            
        transaction.Date        = imput.Date        ?? transaction.Date;
        transaction.Amount      = imput.Amount      ?? transaction.Amount;
        transaction.Type        = imput.Type        ?? transaction.Type;
        transaction.Description = imput.Description ?? transaction.Description;
        transaction.UpdatedAt   = imput.UpdatedAt;

        await transactionRepository.Update(transaction);
        return Result<Transaction>.Ok("Transaction updated successfully", transaction);
    }

    public async Task<Result<Transaction>> DeleteTransaction(int id)
    {
        var transaction = await transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return Result<Transaction>.Fail("Transaction not found", HttpStatusCode.NotFound);
        await transactionRepository.Delete(transaction);
        return Result<Transaction>.Ok("Transaction deleted successfully", transaction);
    }
}
