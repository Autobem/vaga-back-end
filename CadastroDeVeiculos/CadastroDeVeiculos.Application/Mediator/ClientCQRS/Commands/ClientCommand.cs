using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.ValueObject;
using MediatR;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands
{
    public abstract class ClientCommand : IRequest<Client>
    {
        public Name Name { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Email { get;  set; }
        public string Document { get;  set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
