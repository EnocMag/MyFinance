using MediatR;
using MyFinance.Domain.DTOs.Responses;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Enums;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Commands.Categories;

public class GetCategoriesByTypeQuery : IRequest<Result<IEnumerable<Category>>>
{
    public TransactionType Type { get; set; }
}

public class GetCategoriesByTypeQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoriesByTypeQuery, Result<IEnumerable<Category>>>
{
    public async Task<Result<IEnumerable<Category>>> Handle(GetCategoriesByTypeQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetCategoriesByType(request);
    }
}