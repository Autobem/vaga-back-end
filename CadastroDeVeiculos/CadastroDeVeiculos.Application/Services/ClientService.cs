using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(ClientDTO entity)
        {
            var userEntity = _mapper.Map<Client>(entity);
            await this._clientRepository.CreateAsync(userEntity);

        }

        public async Task UpdateAsync(ClientDTO entity)
        {

            var userEntity = this._mapper.Map<Client>(entity);
            await this._clientRepository.UpdateAsync(userEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var userEntity = this._clientRepository.GetByIdAsync(id).Result;
            await this._clientRepository.DeleteAsync(userEntity.Id);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync(int pageSize, int pageActual)
        {
            var list = await this._clientRepository.GetAllAsync(pageSize, pageActual);
            return list.MapTo<IEnumerable<Client>, IEnumerable<ClientDTO>>();
        }

        public async Task<ClientDTO> GetAsync(int id)
        {
            var entity = await this._clientRepository.GetByIdAsync(id);
            return entity.MapTo<Client, ClientDTO>();
        }
    }
}
