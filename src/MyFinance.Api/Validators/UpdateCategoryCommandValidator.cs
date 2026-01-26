using FluentValidation;
using MyFinance.Domain.Commands.Categories;

namespace MyFinance.Api.Validators;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100).When(x => x.Name != null).WithMessage("Category name must not exceed 100 characters.");
        RuleFor(x => x.Type)
            .IsInEnum().When(x => x.Type.HasValue).WithMessage("Invalid transaction type for category.");
    }
}
