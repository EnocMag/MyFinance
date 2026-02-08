using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using System.Net;

namespace MyFinance.Domain.Commands.Categories;

public class GetCategoryQuery : IRequest<Result<Category>>
{
    public int Id { get; set; }
}

public class GetCategoryQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryQuery, Result<Category>>
{
    public async Task<Result<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id);
        if (category == null) 
        {
            return Result<Category>.Fail("The category with the provided Id was not found.", HttpStatusCode.NotFound);
        }
        return Result<Category>.Ok("Category retrived successfully.", category);
    }
}