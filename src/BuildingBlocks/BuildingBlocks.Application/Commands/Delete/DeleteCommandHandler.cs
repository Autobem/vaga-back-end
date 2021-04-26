using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Commands.Delete
{
    public abstract class DeleteCommandHandler<TModel, TDeleteCommand, TRepository> : IRequestHandler<TDeleteCommand>
        where TModel : IModel, new()
        where TDeleteCommand : DeleteCommand
        where TRepository : ICrudRepository<TModel>
    {
        [Inject]
        public TRepository Repository { get; set; }

        public Task<MediatR.Unit> Handle(TDeleteCommand request, CancellationToken cancellationToken)
        {
            this.Repository.Delete(request.Id, cancellationToken);

            return MediatR.Unit.Task;
        }
    }
}
