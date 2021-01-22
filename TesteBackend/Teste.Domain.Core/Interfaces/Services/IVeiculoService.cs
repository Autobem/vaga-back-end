using System.Collections.Generic;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Services
{
    public interface IVeiculoService
    {
        void Adicionar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Remover(int id);
        Veiculo ObterPorId(int id);
        IEnumerable<Veiculo> ObterTodos();
    }
}
