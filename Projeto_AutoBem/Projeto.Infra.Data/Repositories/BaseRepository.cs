using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Bases;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DataContext dataContext;

        //construtor para injeção de dependência
        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return dataContext.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().Where(where).ToList();
        }

        public TEntity Get(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().FirstOrDefault(where);
        }

        public int Count()
        {
            return dataContext.Set<TEntity>().Count();
        }

        public int Count(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().Count(where);
        }
    }
}
