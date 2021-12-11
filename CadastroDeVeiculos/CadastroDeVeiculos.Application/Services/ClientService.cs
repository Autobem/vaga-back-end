using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands;
using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Queries;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Services
{
    public class ClientService : IClientService
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public ClientService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task CreateAsync(ClientDTO entityDTO)
        {
            var clientCreateCommand = this._mapper.Map<ClientCreateCommand>(entityDTO);

            await this._mediator.Send(clientCreateCommand);
        }

        public async Task UpdateAsync(ClientDTO entityDTO)
        {
            var clientUpdateCommand = this._mapper.Map<ClientUpdateCommand>(entityDTO);

            await this._mediator.Send(clientUpdateCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var clientRemoveCommand = new ClientRemoveCommand(id);

            await this._mediator.Send(clientRemoveCommand);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var clientsQuery = new GetClientsQuery();

            var result = await this._mediator.Send(clientsQuery);

            return result.MapTo<IEnumerable<Client>, IEnumerable<ClientDTO>>();
        }

        public async Task<ClientDTO> GetAsync(int id)
        {
            var clientQuery = new GetClientByIdQuery(id);

            var result = await this._mediator.Send(clientQuery);

            return result.MapTo<Client, ClientDTO>();
        }
    }
}
