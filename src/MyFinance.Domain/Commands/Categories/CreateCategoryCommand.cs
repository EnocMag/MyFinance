using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Categories;

public class CreateCategoryCommand : IRequest<Result<Category>>
{
    public string Name { get; set; }
    public TransactionType Type { get; set; }
}

public class CreateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryCommand, Result<Category>>
{
    public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.CreateCategoryAsync(request);
    }
}