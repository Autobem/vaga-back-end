using System.Collections.Generic;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        void Adicionar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Remover(int id);
        Veiculo ObterPorId(int id);
        IEnumerable<Veiculo> ObterTodos();
    }
}
