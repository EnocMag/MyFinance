using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    public string GenerateJwtToken(string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("clave-secreta-muy-larga-para-generar-el-token");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", userId) }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Issuer = "MyFinanceAuthIssuer",
            //Audience = "taxis.com",
            //Claims = new Dictionary<string, object>
            //{
            //    { "roles", "Admin" }
            //}
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
