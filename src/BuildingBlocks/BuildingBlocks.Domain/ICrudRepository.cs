using BuildingBlocks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BuildingBlocks.Domain
{
    public interface ICrudRepository<TModel> where TModel : IModel, new()
    {
        TModel Get(Guid id, CancellationToken token = default);

        TModel Insert(TModel model, CancellationToken token = default);

        void Update(TModel model, CancellationToken token = default);

        void Delete(Guid id, CancellationToken token = default);

        IEnumerable<TModel> ListAll(CancellationToken cancellationToken);
    }
}
