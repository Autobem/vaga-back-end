using Domain.Contracts.Service;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Service;

public class PasswordService : IPasswordService
{
    private readonly string? _pepper;

    public PasswordService(IConfiguration configuration)
    {
        _pepper = configuration.GetSection("PasswordPepper")["pepper"];
    }

    public virtual string HashPassword(string password, string salt = "", int iteration = 3)
    {
        if (iteration <= 0)
            return password;

        if (string.IsNullOrWhiteSpace(salt))
            salt = GenerateSalt();

        using (var sha256 = SHA256.Create())
        {
            var passwordSaltPepper = $"{password}{salt}{_pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return HashPassword(hash, salt, iteration - 1);
        };
    }

    public virtual string GenerateSalt()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        };
    }
}