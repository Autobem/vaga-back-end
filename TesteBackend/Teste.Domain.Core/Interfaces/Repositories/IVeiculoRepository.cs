using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        Task Adicionar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Remover(int id);
        Task<Veiculo> ObterPorId(int id);
        Task<IEnumerable<Veiculo>> ObterTodos();
    }
}
