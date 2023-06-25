using System.Security.Cryptography.X509Certificates;

namespace Domain.Contracts.Service
{
    public interface IPasswordService
    {
        string HashPassword(string password, string salt, int iteration);
    }
}