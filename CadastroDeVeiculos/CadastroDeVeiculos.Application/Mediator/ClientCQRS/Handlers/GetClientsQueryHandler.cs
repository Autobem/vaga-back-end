using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Handlers
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientsQueryHandler(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            return await this._clientRepository.GetAllAsync();
        }
    }
}
