using AutoBem.Application.Users.Query.Register;
using BuildingBlocks.Mediator.Requests;
using BuildingBlocks.WebApi;
using BuildingBlocks.WebApi.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AutoBem.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/users")]
    public class UserController : BaseController
    {
        public IMediator Mediator { get; set; }

        public UserController(IMediator mediator)
        {
            this.Mediator = mediator;
        }


        [HttpPost()]
        [ProducesResponseType(typeof(IRequestResponse<SigninUserResult>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PostAsync(SigninUserQuery command)
        {
            var result = await this.Mediator.Send(command);
            if (result.IsSuccess)
            {
                return this.ResponseModel(result);
            }

            return this.ResponseModel(result, HttpStatusCode.BadRequest);
        }

    }
}
