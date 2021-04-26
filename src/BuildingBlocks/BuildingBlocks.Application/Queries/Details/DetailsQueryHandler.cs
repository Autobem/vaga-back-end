using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Queries.Details
{
    public abstract class DetailsQueryHandler<TModel, TDetailsQuery, TDetailsResult, TRepository> : IRequestHandler<TDetailsQuery, TDetailsResult>
          where TModel : IModel, new()
          where TDetailsQuery : DetailsQuery<TModel, TDetailsResult>
          where TDetailsResult : DetailsResult<TModel>, new()
          where TRepository : ICrudRepository<TModel>
    {
        [Inject]
        public TRepository Repository { get; set; }

        public Task<TDetailsResult> Handle(TDetailsQuery request, CancellationToken cancellationToken)
        {
            var model = this.Repository.Get(request.Id, cancellationToken);
            var result = new TDetailsResult().FromModel(model);

            return Task.FromResult(result as TDetailsResult);
        }
    }
}
