using Model.Infra.Data.Context;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PostgresContext _postgresContext;

        public BaseRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public void Insert(TEntity obj)
        {
            _postgresContext.Set<TEntity>().Add(obj);
            _postgresContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _postgresContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _postgresContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _postgresContext.Set<TEntity>().Remove(Select(id));
            _postgresContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _postgresContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _postgresContext.Set<TEntity>().Find(id);

    }
}
