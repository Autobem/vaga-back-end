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
    public class ClientRemoveCommandHandler : IRequestHandler<ClientRemoveCommand, Client>
    {

        private readonly IClientRepository _clientRepository;
        private readonly INotificationContext _notification;

        public ClientRemoveCommandHandler(IClientRepository clientRepository, INotificationContext notification)
        {
            this._clientRepository = clientRepository;
            this._notification = notification;
        }

        public async Task<Client> Handle(ClientRemoveCommand request, CancellationToken cancellationToken)
        {
            var client = await this._clientRepository.GetByIdAsync(request.Id);

            if (client == null)
            {
                this._notification.AddNotification("Client", Message.NotFound.Description());
            }

            var result = await this._clientRepository.DeleteAsync(client.Id);
            return result;
        }
    }
}
