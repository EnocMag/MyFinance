using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.Commands.Categories;

namespace MyFinance.Api.Controllers;

public class CategoryController(IMediator mediator, ILogger<CategoryController> logger) : BaseController(mediator, logger)
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand input) =>
    await processCommand(input);

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetCategoryById(int id) =>
        await processCommand(new GetCategoryQuery { Id = id });
    [HttpGet]
    public async Task<IActionResult> GetAllCategorys() =>
        await processCommand(new GetAllCategoriesQuery());

    [HttpPatch("/{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand input)
    {
        input.Id = id;
        return await processCommand(input);
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteCategory(int id) =>
        await processCommand(new DeleteCategoryCommand { Id = id });
}
