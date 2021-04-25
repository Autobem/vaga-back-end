using BuildingBlocks.Ioc.Attributes;
using MediatR;

namespace BuildingBlocks.Mediator.Requests.Implementation
{
    [Injectable]
    public class Mediator : MediatR.Mediator, IMediator
    {
        public Mediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }
    }
}
