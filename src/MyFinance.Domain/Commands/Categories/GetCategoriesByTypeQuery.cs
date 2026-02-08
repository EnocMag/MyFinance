using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Categories;

public class GetCategoriesByTypeQuery : IRequest<Result<IEnumerable<Category>>>
{
    public TransactionType Type { get; set; }
}

public class GetCategoriesByTypeQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesByTypeQuery, Result<IEnumerable<Category>>>
{
    public async Task<Result<IEnumerable<Category>>> Handle(GetCategoriesByTypeQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetByTypeAsync(request.Type);
        return Result<IEnumerable<Category>>.Ok("Categories retrieved successfully.", categories);
    }
}