using MyFinance.Domain.Services.Interfaces;

namespace MyFinance.Domain.Services.Implementations;

public class UserService : IUserService
{
    private static readonly List<User> Users = new()
    {
        new User { Id = "1", Username = "testuser", Password = "password123" },
        new User { Id = "2", Username = "alice", Password = "alicepass" },
        new User { Id = "3", Username = "bob", Password = "bobpass" }
    };
    public User Login(string username, string password)
    {
        // Validación básica de parámetros
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return null;
        }

        // Buscar usuario en la lista por username y password
        // Comparación exacta (case-sensitive). Para case-insensitive:
        // Users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)
        //                         && string.Equals(u.Password, password, StringComparison.Ordinal));
        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        return user;
    }
}
public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}