using AutoBem.Domain.Users.Models;
using BuildingBlocks.Application.Requests;

namespace AutoBem.Application.Users.Query.Register
{
    public class SigninUserQuery : IRequest<SigninUserResult>
    {
        public string Username { get; set; }

        public string Password { get; set; }


        public User ToModel()
        {
            return new User()
            {
                Username = Username,
                Password = Password
            };
        }
    }
}
