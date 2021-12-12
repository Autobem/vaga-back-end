using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries
{
    public class GetUserLoginQuery : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public GetUserLoginQuery(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
