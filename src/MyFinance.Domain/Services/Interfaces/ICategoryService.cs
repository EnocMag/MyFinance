using MyFinance.Domain.Commands.Categories;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;

namespace MyFinance.Domain.Services.Interfaces;

public interface ICategoryService
{
    Task<Result<Category>> CreateCategoryAsync(CreateCategoryCommand input);
    Task<Result<Category>> UpdateCategoryAsync(UpdateCategoryCommand input);
    Task<Result<Category>> DeleteCategoryAsync(int id);
}
