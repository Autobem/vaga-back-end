using System.Collections.Generic;

namespace BuildingBlocks.WebApi.Responses
{
    public class ExceptionResponse
    {
        public List<string> Messages { get; set; } = new List<string>();

        public object Exception { get; set; }
    }
}
