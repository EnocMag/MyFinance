using MyFinance.Domain.Commands.Categories;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Interfaces;
using System.Net;

namespace MyFinance.Domain.Services.Implementations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Result<Category>> CreateCategoryAsync(CreateCategoryCommand input)
    {
        if (await categoryRepository.NameExistsAsync(input.Name))
            return Result<Category>.Fail($"The category with the name '{input.Name}' already exists.");

        var category = new Category
        {
            Name = input.Name,
            Type = input.Type
        };

        await categoryRepository.AddAsync(category);
        return Result<Category>.Ok("Category created successfully", category);
    }

    public async Task<Result<Category>> UpdateCategoryAsync(UpdateCategoryCommand input)
    {
        var category = await categoryRepository.GetByIdAsync(input.Id);
        if (category == null)
            return Result<Category>.Fail("The category with the provided Id was not found.", HttpStatusCode.NotFound);

        if (!string.IsNullOrEmpty(input.Name) && input.Name != category.Name) category.Name = input.Name;
        if (input.Type.HasValue && input.Type != category.Type) category.Type = input.Type.Value;

        await categoryRepository.Update(category);
        return Result<Category>.Ok("Category updated successfuly.", category);
    }

    public async Task<Result<Category>> DeleteCategoryAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category == null)
            return Result<Category>.Fail("Category not found", HttpStatusCode.NotFound);
        await categoryRepository.Delete(category);
        return Result<Category>.Ok("Category deleted successfuly.");
    }
}
