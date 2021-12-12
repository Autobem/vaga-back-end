using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Handlers
{
    public class VehicleUpdateCommandHandler : IRequestHandler<VehicleUpdateCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly INotificationContext _notificationContext;

        public VehicleUpdateCommandHandler(IVehicleRepository vehicleRepository, INotificationContext notificationContext)
        {
            this._vehicleRepository = vehicleRepository;
            this._notificationContext = notificationContext;
        }

        public async Task<Vehicle> Handle(VehicleUpdateCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await this._vehicleRepository.GetByIdAsync(request.Id);

            if (vehicle == null)
            {
                this._notificationContext.AddNotification("vehicle", Message.NotFound.Description());
            }

            vehicle.UpdateVehicle(request.ModelName, request.Brand, request.YearOfManufacturer, request.Plate);

            if (vehicle.Invalid)
            {
                this._notificationContext.AddNotification("vehicle", Message.RequestInvalid.Description());
            }

            return await this._vehicleRepository.UpdateAsync(vehicle);
            
        }
    }
}
