using DevAssuncaoCarros.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> ObterTodos();
        Task<TEntidade> ObterPorId(Guid id);
        Task<TEntidade> Remover(Guid id);
        Task<TEntidade> Adicionar(TEntidade entidade);
        Task<TEntidade> Atualizar(TEntidade entidade);
        Task<int> SaveChanges();
    }
}
