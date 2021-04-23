using BuildingBlocks.Ioc.Attributes;
using BuildingBlocks.WebApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AutoBem.WebApi.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : BaseController
    {
        public ClientController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Inject]
        public IMediator Mediator { get; set; }

        [HttpGet("list-all")]
        public IActionResult List()
        {
            return this.ResponseModel(null);
        }
    }
}
