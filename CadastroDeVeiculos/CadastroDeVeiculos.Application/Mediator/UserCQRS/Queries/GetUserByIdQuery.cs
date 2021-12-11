using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
