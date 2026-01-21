using FluentValidation;
using MyFinance.Domain.Commands.Transactions;

namespace MyFinance.Api.Validators;

public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Transaction Id must be greater than zero.");
        RuleFor(x => x.Amount)
            .GreaterThan(0).When(x => x.Amount.HasValue).WithMessage("Amount must be greater than zero.");
        RuleFor(x => x.Description)
            .MaximumLength(250).When(x => !string.IsNullOrEmpty(x.Description)).WithMessage("Description cannot exceed 250 characters.");
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).When(x => x.Date.HasValue).WithMessage("Transaction date cannot be in the future.");
        RuleFor(x => x.Type)
            .IsInEnum().When(x => x.Type.HasValue).WithMessage("Invalid transaction type.");
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).When(x => x.CategoryId.HasValue).WithMessage("Category Id must be greater than zero.");
    }
}
