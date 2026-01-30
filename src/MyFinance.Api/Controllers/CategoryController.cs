using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.Commands.Categories;

namespace MyFinance.Api.Controllers;

public class CategoryController(IMediator mediator, ILogger<CategoryController> logger) : BaseController(mediator, logger)
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand input) =>
    await processCommand(input);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id) =>
        await processCommand(new GetCategoryQuery { Id = id });
    [HttpGet]
    //[Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllCategories() =>
        await processCommand(new GetAllCategoriesQuery());
    [HttpGet]
    public async Task<IActionResult> GetExpenseCategories([FromBody] GetCategoriesByTypeQuery input) =>
        await processCommand(input);

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand input)
    {
        input.Id = id;
        return await processCommand(input);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id) =>
        await processCommand(new DeleteCategoryCommand { Id = id });
}
