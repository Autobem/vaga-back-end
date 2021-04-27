using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Queries.List
{
    public abstract class ListAllQueryHandler<TModel, TListQuery, TDetailsResult, TRepository> : IRequestHandler<TListQuery, IEnumerable<TDetailsResult>>
          where TModel : IModel, new()
          where TListQuery : ListAllQuery<TModel, TDetailsResult>
          where TDetailsResult : ListResult<TModel>, new()
          where TRepository : ICrudRepository<TModel>
    {
        [Inject]
        public TRepository Repository { get; set; }

        public virtual Task<IEnumerable<TDetailsResult>> Handle(TListQuery request, CancellationToken cancellationToken)
        {
            var allModel = this.Repository.ListAll(cancellationToken);
            var result = new List<TDetailsResult>();

            foreach (var model in allModel)
            {
                result.Add(new TDetailsResult().FromModel(model) as TDetailsResult);
            }

            return Task.FromResult(result as IEnumerable<TDetailsResult>);
        }
    }
}
