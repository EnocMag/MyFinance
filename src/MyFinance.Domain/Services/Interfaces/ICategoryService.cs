using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;

namespace MyFinance.Domain.Services.Interfaces;

public interface ICategoryService
{
    Task<Result<Category>> CreateCategoryAsync(Category category);
}
