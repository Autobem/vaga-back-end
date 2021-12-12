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
    public class VehicleCreateCommandHandler : IRequestHandler<VehicleCreateCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly INotificationContext _notificationContext;

        public VehicleCreateCommandHandler(IVehicleRepository vehicleRepository, INotificationContext notificationContext)
        {
            this._vehicleRepository = vehicleRepository;
            this._notificationContext = notificationContext;
        }

        public async Task<Vehicle> Handle(VehicleCreateCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(request.ModelName, request.Brand, request.YearOfManufacturer, request.Plate);

            if (vehicle == null || vehicle.Invalid)
            {
                this._notificationContext.AddNotification("Vechicle", Message.RequestInvalid.Description());
            }

            return await this._vehicleRepository.CreateAsync(vehicle);
        }
    }
}
