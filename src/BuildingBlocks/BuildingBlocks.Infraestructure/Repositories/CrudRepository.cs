using BuildingBlocks.Domain;
using BuildingBlocks.Infraestructure.Converters;
using BuildingBlocks.Infraestructure.Entities;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BuildingBlocks.Infraestructure.Repositories
{
    public abstract class CrudRepository<TModel, TEntity> : ICrudRepository<TModel>
        where TModel : class, new()
        where TEntity : class, ICommonEntity
    {
        [Inject]
        public IDbContext Context { get; set; }

        [Inject]
        public IMappedEntity<TModel, TEntity> Mapper { get; set; }


        public DbSet<TEntity> DbSet => this.Context.Set<TEntity>();

        public virtual TModel Insert(TModel model, CancellationToken token = default)
        {
            var entity = this.Mapper.ToEntity(model);
            this.Context.Set<TEntity>().Add(entity);
            this.Context.SaveChanges();

            return this.Mapper.ToModel(entity);
        }
    }
}
