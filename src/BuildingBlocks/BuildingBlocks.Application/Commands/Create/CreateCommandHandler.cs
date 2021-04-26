using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Commands.Create
{
    public abstract class CreateCommandHandler<TModel, TCreateCommand, TCreateResult, TRepository> : IRequestHandler<TCreateCommand, TCreateResult>
        where TModel : IModel, new()
        where TCreateCommand : CreateCommand<TModel, TCreateResult>
        where TCreateResult : CreateResult, new()
        where TRepository : ICrudRepository<TModel>
    {

        [Inject]
        public TRepository Repository { get; set; }

        public Task<TCreateResult> Handle(TCreateCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToModel();
            var result = this.Repository.Insert(model, cancellationToken);

            var createResult = new TCreateResult()
            {
                Id = result.Id.Value
            };

            return Task.FromResult(createResult);
        }
    }
}
