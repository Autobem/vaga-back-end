using BuildingBlocks.Application.Requests;
using System;

namespace BuildingBlocks.Application.Commands.Update
{
    public abstract class UpdateCommand<TModel> : IRequest
    {
        public Guid Id { get; set; }

        public abstract TModel ToModel();
    }
}
