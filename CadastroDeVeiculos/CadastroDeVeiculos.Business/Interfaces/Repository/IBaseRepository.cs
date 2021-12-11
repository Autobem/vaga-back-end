using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Business.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id);
        bool Exist(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAllAsync(int pageSize, int pageActual);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null);
    }
}
