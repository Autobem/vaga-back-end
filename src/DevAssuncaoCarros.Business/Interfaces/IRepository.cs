using DevAssuncaoCarros.Business.Models;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> ObterTodos();
        Task<TEntidade> ObterPorId(Guid id);
        Task Remover(Guid id);
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task<int> SaveChanges();
    }
}
