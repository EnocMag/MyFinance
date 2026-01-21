using FluentValidation;
using MyFinance.Domain.Commands.Categories;

namespace MyFinance.Api.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid transaction type for category.");
    }
}
