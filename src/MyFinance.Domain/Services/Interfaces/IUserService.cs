using MyFinance.Domain.Services.Implementations;

namespace MyFinance.Domain.Services.Interfaces;

public interface IUserService
{
    User Login(string username, string password);
}
