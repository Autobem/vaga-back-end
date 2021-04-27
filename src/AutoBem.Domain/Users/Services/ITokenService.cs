using AutoBem.Domain.Users.Models;

namespace AutoBem.Domain.Users.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
