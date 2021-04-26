using BuildingBlocks.Application.Requests;
using System;

namespace BuildingBlocks.Application.Queries.Details
{
    public abstract class DetailsQuery<TModel, TDetailsResult> : IRequest<TDetailsResult>
        where TDetailsResult : DetailsResult<TModel>
    {
        public Guid Id { get; set; }

        public DetailsQuery(Guid id)
        {
            Id = id;
        }
    }
}
