
namespace BuildingBlocks.Infraestructure.Converters
{
    public interface IMappedEntity<TModel, TEntity>
    {
        TEntity ToEntity(TModel model);

        TModel ToModel(TEntity entity);
    }
}
