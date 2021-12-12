using CadastroDeVeiculos.Domain.Entities;
using MediatR;

namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands
{
    public abstract class VehicleCommand : IRequest<Vehicle>
    {
        public string ModelName { get;  set; }
        public string Brand { get;  set; }
        public int YearOfManufacturer { get;  set; }
        public string Plate { get;  set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
