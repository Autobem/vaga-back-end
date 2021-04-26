using BuildingBlocks.WebApi;
using System.Net;


namespace BuildingBlocks.Test.Request
{
    public class ResponseMessage<TContent>
    {
        public HttpStatusCode StatusCode { get; set; }


        public IRequestResponse<TContent> Content { get; set; }

    }
}
