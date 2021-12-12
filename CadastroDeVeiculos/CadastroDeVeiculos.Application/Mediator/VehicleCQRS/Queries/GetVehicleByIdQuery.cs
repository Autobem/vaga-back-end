using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Queries
{
    public class GetVehicleByIdQuery : IRequest<Vehicle>
    {
        public int Id { get; set; }

        public GetVehicleByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
