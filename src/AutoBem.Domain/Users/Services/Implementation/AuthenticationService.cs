using AutoBem.Domain.Users.Models;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Domain.Users.Services.Implementation
{
    [Injectable]
    public class AuthenticationService : IAuthenticationService
    {
        [Inject]
        public IUserRepository Repository { get; set; }

        [Inject]
        public ITokenService TokenService { get; set; }


        public SigninResult Signin(string userName, string password)
        {
            var user = Repository.GetByUserName(userName);
            if (user is null || !user.TrySignin(password))
            {
                return new SigninResult()
                {
                    IsSuccess = false,
                    Message = "Usuário ou senha inválido."
                };
            }

            var token = this.TokenService.GenerateToken(user);
            return new SigninResult()
            {
                IsSuccess = true,
                Token = token
            };
        }
    }
}
