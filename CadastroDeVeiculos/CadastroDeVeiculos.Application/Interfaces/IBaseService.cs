using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
    }
}
