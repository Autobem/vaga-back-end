using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Queries
{
    public class GetVehiclesQuery : IRequest<IEnumerable<Vehicle>>
    {
    }
}
