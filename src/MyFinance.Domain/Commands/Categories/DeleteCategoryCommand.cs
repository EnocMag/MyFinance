using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Categories;

public class DeleteCategoryCommand : IRequest<Result<Category>>
{
    public int Id { get; set; }
}

public class DeleteCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, Result<Category>>
{
    public async Task<Result<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.DeleteCategoryAsync(request.Id);
    }
}