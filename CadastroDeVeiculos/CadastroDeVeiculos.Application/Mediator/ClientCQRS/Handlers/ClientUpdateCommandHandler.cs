using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Business.NotificationHandlers;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Handlers
{
    public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, Client>
    {
        private readonly IClientRepository _clientRepository;
        private NotificationContext _notification;

        public ClientUpdateCommandHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            this._clientRepository = clientRepository;
            this._notification = notification;
        }

        public async Task<Client> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await this._clientRepository.GetByIdAsync(request.Id);

            if (client == null)
            {
                this._notification.AddNotification("Client", Message.NotFound.Description());
            }

            client.UpdateClient(request.Name, request.PhoneNumber, request.Email, request.Document);

            return await this._clientRepository.UpdateAsync(client);
        }
    }
}
