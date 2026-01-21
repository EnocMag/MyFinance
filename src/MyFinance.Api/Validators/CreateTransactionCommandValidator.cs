using FluentValidation;
using MyFinance.Domain.Commands.Transactions;

namespace MyFinance.Api.Validators;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Transaction date cannot be in the future.");
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.");
        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid transaction type.");
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");
    }
}
