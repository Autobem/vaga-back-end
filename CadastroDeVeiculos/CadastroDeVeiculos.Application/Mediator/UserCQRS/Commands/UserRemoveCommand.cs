using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands
{
    public class UserRemoveCommand : IRequest<User> 
    {
        public int Id { get; set; }

        public UserRemoveCommand(int id)
        {
            this.Id = id;
        }
    }
}
