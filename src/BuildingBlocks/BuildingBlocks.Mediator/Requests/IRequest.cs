namespace BuildingBlocks.Application.Requests
{
    public interface IRequest<out TResponse> : MediatR.IRequest<TResponse>
    {
    }

    public interface IRequest : MediatR.IRequest
    {
    }
}
