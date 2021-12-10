using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Data.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        protected DbSet<TEntity> Dbset => this._dbContext.Set<TEntity>();

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

    
        public async Task CreateAsync(TEntity entity)
        {
            Dbset.Add(entity);
            this._dbContext.Entry(entity).State = EntityState.Added;
            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Dbset.Update(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindAsync(x => x.Id == id);
            
            if (entity == null)
            {
                return;
            }

            if (this._dbContext.Entry(entity).State == EntityState.Detached)
            {
                Dbset.Attach(entity);
            }

            Dbset.Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await FindAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int pageSize, int pageActual)
        {
            return await this._dbContext.Set<TEntity>().OrderBy(x => x.Id).Skip((pageActual - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null)
        {
            return await Query(where, order).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null)
        {
            IQueryable<TEntity> query = this._dbContext.Set<TEntity>();

            if (where != null)
            {
                query = query.Where(where);
            }

            if (order != null)
            {
                return order(query);
            }

            return query;
        }

        public bool Exist(Expression<Func<TEntity, bool>> where)
        {
            return this._dbContext.Set<TEntity>().Any(where);
        }
    }
}
