using Domain.Contracts.Service;
using Microsoft.Extensions.Configuration;

namespace Domain.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly string? _pepper;

        public PasswordService(IConfiguration configuration)
        {
            _pepper = configuration.GetSection("PasswordPepper")["pepper"];
        }

        public virtual string HashPassword(string password, string salt = "", int iteration = 3)
        {
            if(iteration <= 0) return password;
            return HashPassword(password, salt, iteration - 1);
        }
    }
}