using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Bases
{
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);

        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
