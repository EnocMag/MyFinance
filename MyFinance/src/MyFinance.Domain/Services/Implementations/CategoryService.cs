using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Services.Implementations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Result<Category>> CreateCategoryAsync(Category category)
    {
        // Check if category with the same name already exists
        //var existingCategory = await categoryRepository.GetByNameAsync(category.Name);
        await categoryRepository.AddAsync(category);
        return Result<Category>.Ok("Category created successfully", category);
    }
}
