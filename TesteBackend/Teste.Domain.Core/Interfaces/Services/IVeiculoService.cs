using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<bool> Adicionar(Veiculo veiculo);
        Task<bool> Atualizar(Veiculo veiculo);
        Task<bool> Remover(int id);
    }
}
