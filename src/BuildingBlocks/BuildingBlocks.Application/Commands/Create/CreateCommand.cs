using BuildingBlocks.Application.Requests;

namespace BuildingBlocks.Application.Commands.Create
{
    public abstract class CreateCommand<TModel, TCreateResult> : IRequest<TCreateResult>
        where TCreateResult : CreateResult
    {
        public abstract TModel ToModel();

    }
}
