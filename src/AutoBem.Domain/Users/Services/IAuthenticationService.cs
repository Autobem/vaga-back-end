using AutoBem.Domain.Users.Models;

namespace AutoBem.Domain.Users.Services
{
    public interface IAuthenticationService
    {
        SigninResult Signin(string userName, string password);
    }
}
