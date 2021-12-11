using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Queries
{
    public class GetClientsQuery : IRequest<IEnumerable<Client>>
    {
    }
}
