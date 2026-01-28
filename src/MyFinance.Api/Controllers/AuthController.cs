using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.DTOs.Requests;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService, IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        // Authenticate user
        var user = userService.Login(model.Username, model.Password);

        if (user == null)
            return Unauthorized();

        // Generate JWT token
        var token = authenticationService.GenerateJwtToken(user.Id);

        return Ok(new { token });
    }
}
