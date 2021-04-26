using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<TDetailsResult>> Handle(TListQuery request, CancellationToken cancellationToken)
        {
            var model = this.Repository.ListAll(cancellationToken);
            var result = model.Select(e => new TDetailsResult().FromModel(e));

            return Task.FromResult(result as IEnumerable<TDetailsResult>);
        }
    }
}
