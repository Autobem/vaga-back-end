using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
         Task<Veiculo> PostAsync(Veiculo model);
        Task<Veiculo> PutAsync(Veiculo model);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<Veiculo>> GetAsync();
        Task<Veiculo> GetAsync(int id);
    }
}