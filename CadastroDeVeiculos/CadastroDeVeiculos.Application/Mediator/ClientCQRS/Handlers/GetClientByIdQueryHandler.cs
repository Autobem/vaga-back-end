using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Handlers
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepository _clientRepository;
      

        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            return await this._clientRepository.GetByIdAsync(request.Id);
        }
    }
}
