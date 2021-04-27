using BuildingBlocks.Application.Requests;
using System.Collections.Generic;

namespace BuildingBlocks.Application.Queries.List
{
    public abstract class ListAllQuery<TModel, TListResult> : IRequest<IEnumerable<TListResult>>
         where TListResult : ListResult<TModel>
    {
    }
}
