using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.Commands.Transactions;

namespace MyFinance.Api.Controllers;

public class TransactionController(IMediator mediator, ILogger<TransactionController> logger) : BaseController(mediator, logger)
{
    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand input) =>
        await processCommand(input);

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetTransactionById(int id) =>
        await processCommand(new GetTransactionQuery { Id = id });
    [HttpGet]
    public async Task<IActionResult> GetAllTransactions() =>
        await processCommand(new GetAllTransactionsQuery());

    [HttpPatch("/{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionCommand input)
    {
        input.Id = id;
        return await processCommand(input);
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteTransaction(int id) =>
        await processCommand(new DeleteTransactionCommand { Id = id });
}
