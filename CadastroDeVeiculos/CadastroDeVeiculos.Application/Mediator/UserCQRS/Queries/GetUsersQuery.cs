using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {

    }
}
