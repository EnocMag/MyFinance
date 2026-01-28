using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.DTOs.Responses;
using System.Net;

namespace MyFinance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public abstract class BaseController(IMediator mediator, ILogger<BaseController> logger) : ControllerBase
{
    protected async Task<IActionResult> processCommand<T>(IRequest<Result<T>> request) where T : class
    {
        try
        {
            var result = await mediator.Send(request);
            return StatusCode((int)result.State, result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while processing the request.");
            return StatusCode(StatusCodes.Status500InternalServerError,
                Result<T>.Fail("An error occurred while processing the request.", HttpStatusCode.InternalServerError));
        }
    }
}
