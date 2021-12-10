using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Bases
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);

        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity GetById(int id);
        TEntity Get(Func<TEntity, bool> where);

        int Count();
        int Count(Func<TEntity, bool> where);
    }
}
