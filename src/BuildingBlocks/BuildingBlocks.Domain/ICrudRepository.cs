using System.Threading;

namespace BuildingBlocks.Domain
{
    public interface ICrudRepository<TModel> where TModel : class, new()
    {
        TModel Insert(TModel model, CancellationToken token = default);

    }
}
