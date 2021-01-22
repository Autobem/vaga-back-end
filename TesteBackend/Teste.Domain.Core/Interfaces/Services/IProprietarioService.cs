using System.Collections.Generic;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Services
{
    public interface IProprietarioService
    {
        void Adicionar(Proprietario proprietario);
        void Atualizar(Proprietario proprietario);
        void Remover(int id);
        Proprietario ObterPorId(int id);
        IEnumerable<Proprietario> ObterTodos();
    }
}
