using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Handlers
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, IEnumerable<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await this._vehicleRepository.GetAllAsync();
        }
    }
}
