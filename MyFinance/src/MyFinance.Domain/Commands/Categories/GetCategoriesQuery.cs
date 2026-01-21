using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;

namespace MyFinance.Domain.Commands.Categories;

public class GetCategoriesQuery : IRequest<Result<IEnumerable<Category>>>
{
}

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, Result<IEnumerable<Category>>>
{
    public async Task<Result<IEnumerable<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync();
        return Result<IEnumerable<Category>>.Ok("Categories retrieved successfully", categories);
    }
}