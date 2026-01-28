namespace MyFinance.Domain.Services.Interfaces;

public interface IAuthenticationService
{
    string GenerateJwtToken(string userId);
}
