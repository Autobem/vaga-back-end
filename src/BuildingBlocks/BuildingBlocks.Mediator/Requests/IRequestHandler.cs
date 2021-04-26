namespace BuildingBlocks.Application.Requests
{
    public interface IRequestHandler<in TRequest, TResponse> : MediatR.IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
    }

    public interface IRequestHandler<in TRequest> : MediatR.IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}
