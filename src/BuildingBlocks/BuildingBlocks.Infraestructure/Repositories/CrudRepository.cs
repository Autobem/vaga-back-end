using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Infraestructure.Converters;
using BuildingBlocks.Infraestructure.Entities;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BuildingBlocks.Infraestructure.Repositories
{
    public abstract class CrudRepository<TModel, TEntity> : ICrudRepository<TModel>
        where TModel : class, IModel, new()
        where TEntity : class, ICommonEntity
    {
        [Inject]
        public IDbContext Context { get; set; }

        [Inject]
        public IMappedEntity<TModel, TEntity> Mapper { get; set; }


        public DbSet<TEntity> DbSet => this.Context.Set<TEntity>();


        public TModel Get(Guid id, CancellationToken token = default)
        {
            var entity = this.DbSet
                .Where(e => e.Id == id)
                .AsNoTracking()
                .FirstOrDefault();

            if (entity is null)
            {
                return null;
            }

            return this.Mapper.ToModel(entity);
        }

        public virtual TModel Insert(TModel model, CancellationToken token = default)
        {
            var entity = this.Mapper.ToEntity(model);
            this.DbSet.Add(entity);

            token.ThrowIfCancellationRequested();
            this.Context.SaveChanges();

            return this.Mapper.ToModel(entity);
        }

        public void Update(TModel model, CancellationToken token = default)
        {
            var entity = this.Mapper.ToEntity(model);
            this.DbSet.Update(entity);

            token.ThrowIfCancellationRequested();
            this.Context.SaveChanges();
        }

        public void Delete(Guid id, CancellationToken token = default)
        {
            var entity = this.DbSet
                .Where(e => e.Id == id)
                .FirstOrDefault();

            this.DbSet.Remove(entity);

            token.ThrowIfCancellationRequested();
            this.Context.SaveChanges();
        }


        public IEnumerable<TModel> ListAll(CancellationToken cancellationToken)
        {
            return this.DbSet
                .AsNoTracking()
                .Select(e => this.Mapper.ToModel(e));
        }
    }
}
