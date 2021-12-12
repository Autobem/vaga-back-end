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
    public class VehicleRemoveCommandHandler : IRequestHandler<VehicleRemoveCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly INotificationContext _notificationContext;

        public VehicleRemoveCommandHandler(IVehicleRepository vehicleRepository, INotificationContext notificationContext)
        {
            this._vehicleRepository = vehicleRepository;
            this._notificationContext = notificationContext;
        }

        public async Task<Vehicle> Handle(VehicleRemoveCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await this._vehicleRepository.GetByIdAsync(request.Id);

            if (vehicle == null)
            {
                this._notificationContext.AddNotification("vehicle", Message.NotFound.Description());
            }

            return await this._vehicleRepository.DeleteAsync(vehicle.Id);
        }
    }
}
