using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Enums;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands
{
    public abstract class UserCommand : IRequest<User>
    {
        public string LoginData { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
    }
}
