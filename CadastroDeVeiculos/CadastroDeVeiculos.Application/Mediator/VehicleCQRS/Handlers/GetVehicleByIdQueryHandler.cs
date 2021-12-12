using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Handlers
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return await this._vehicleRepository.GetByIdAsync(request.Id);
        }
    }
}
