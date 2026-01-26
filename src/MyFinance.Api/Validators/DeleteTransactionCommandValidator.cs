using FluentValidation;
using MyFinance.Domain.Commands.Transactions;

namespace MyFinance.Api.Validators;

public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
    public DeleteTransactionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("The ID must be greater than zero.");
    }
}
