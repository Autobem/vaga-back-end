using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private IRepository<Veiculo> _repository;

        public VeiculoService(IRepository<Veiculo> repository)
        {
            _repository = repository;
        }        
        
        public async Task<int> DeleteAsync(int id)
        {
           return await _repository.DeletarAsync(id);
        }

        public async Task<IEnumerable<Veiculo>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Veiculo> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Veiculo> PostAsync(Veiculo model)
        {
            return await _repository.AdicionarAsync(model);
        }

        public async Task<Veiculo> PutAsync(Veiculo model)
        {
            return await _repository.AtualizarAsync(model);
        }
    }
}