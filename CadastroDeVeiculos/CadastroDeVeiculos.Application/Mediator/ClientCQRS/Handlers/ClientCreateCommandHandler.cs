using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Handlers
{
    public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, Client>
    {
        public readonly IClientRepository _clientRepository;
        public readonly INotificationContext _notification;

        public ClientCreateCommandHandler(IClientRepository clientRepository, INotificationContext notification)
        {
            this._clientRepository = clientRepository;
            this._notification = notification;
        }

        public async Task<Client> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name, request.PhoneNumber, request.Email, request.Document);

            if (client == null)
            {
                this._notification.AddNotification("Client", Message.RequestInvalid.Description());
            }

            return await this._clientRepository.CreateAsync(client);
        }
    }
}
