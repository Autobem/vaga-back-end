using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Repositories
{
    public interface IProprietarioRepository
    {
        Task Adicionar(Proprietario proprietario);
        Task Atualizar(Proprietario proprietario);
        Task Remover(int id);
        Task<Proprietario> ObterPorId(int id);
        Task<IEnumerable<Proprietario>> ObterTodos();
        Task<IEnumerable<Proprietario>> Buscar(Expression<Func<Proprietario, bool>> predicate);
        Task<Proprietario> ObterProprietarioVeiculos(int id);
    }
}
