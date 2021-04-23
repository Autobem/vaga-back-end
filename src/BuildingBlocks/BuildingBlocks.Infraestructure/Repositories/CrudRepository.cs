using BuildingBlocks.Infraestructure.Converters;
using BuildingBlocks.Infraestructure.Entities;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Infraestructure.Repositories
{
    public abstract class CrudRepository<TModel, TEntity>
        where TEntity : class, ICommonEntity
    {
        [Inject]
        public IDbContext Context { get; set; }

        [Inject]
        public IMappedEntity<TModel, TEntity> Mapper { get; set; }


        public DbSet<TEntity> DbSet => this.Context.Set<TEntity>();

        public virtual async Task<TModel> Insert(TModel model, CancellationToken token = default)
        {
            var entity = this.Mapper.ToEntity(model);
            this.DbSet.Add(entity);
            await this.Context.SaveChangesAsync(token);

            return this.Mapper.ToModel(entity);
        }
    }
}
