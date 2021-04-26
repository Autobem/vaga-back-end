using System.Net;

namespace BuildingBlocks.WebApi
{
    public interface IRequestResponse
    {
        public HttpStatusCode Status { get; set; }
    }

    public interface IRequestResponse<TData>
    {
        public TData Data { get; set; }
    }

    public class RequestResponse<TData> : IRequestResponse<TData>
    {
        public HttpStatusCode Status { get; set; }

        public TData Data { get; set; }
    }
}
