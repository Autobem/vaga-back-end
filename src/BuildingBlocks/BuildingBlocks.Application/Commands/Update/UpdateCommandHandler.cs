using BuildingBlocks.Application.Requests;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Models;
using BuildingBlocks.Ioc.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Commands.Update
{
    public class UpdateCommandHandler<TModel, TUpdateCommand, TRepository> : IRequestHandler<TUpdateCommand>
        where TModel : IModel, new()
        where TUpdateCommand : UpdateCommand<TModel>
        where TRepository : ICrudRepository<TModel>
    {
        [Inject]
        public TRepository Repository { get; set; }


        public virtual Task<MediatR.Unit> Handle(TUpdateCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToModel();
            this.Repository.Update(model, cancellationToken);

            return MediatR.Unit.Task;
        }
    }
}
