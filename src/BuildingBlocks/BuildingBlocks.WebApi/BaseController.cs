using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.WebApi
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Resonse http request
        /// </summary>
        /// <param name="response"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        protected IActionResult ResponseModel(object response = null, HttpStatusCode status = HttpStatusCode.OK)
        {
            if (response is null)
            {
                return this.StatusCode((int)HttpStatusCode.NoContent);
            }

            return this.StatusCode((int)status, new
            {
                status = status,
                data = response
            });
        }

        /// <summary>
        /// Resonse error http request
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [NonAction]
        protected IActionResult ResponseErrorModel(object response)
        {
            if (response is null)
            {
                return this.StatusCode((int)HttpStatusCode.NoContent);
            }

            return this.StatusCode((int)HttpStatusCode.InternalServerError, new
            {
                status = HttpStatusCode.InternalServerError,
                data = response
            });
        }
    }
}
