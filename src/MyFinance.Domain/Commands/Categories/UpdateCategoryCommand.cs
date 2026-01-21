using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Categories;

public class UpdateCategoryCommand : IRequest<Result<Category>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TransactionType Type { get; set; }
}

public class UpdateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryCommand, Result<Category>>
{
    public async Task<Result<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.UpdateCategoryAsync(request);
    }
}