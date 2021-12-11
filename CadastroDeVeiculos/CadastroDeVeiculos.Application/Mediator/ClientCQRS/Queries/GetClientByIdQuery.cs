using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id { get; set; }

        public GetClientByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
