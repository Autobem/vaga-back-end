using System.Collections.Generic;

namespace Autobem.Application.Interfaces
{
    public interface IBaseServiceApp<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
