using AutoBem.Application.Clients.Commands.Create;
using AutoBem.Application.Clients.Commands.Delete;
using AutoBem.Application.Clients.Commands.Update;
using AutoBem.Application.Clients.Queries.Details;
using AutoBem.Application.Clients.Queries.ListAll;
using BuildingBlocks.Mediator.Requests;
using BuildingBlocks.WebApi;
using BuildingBlocks.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoBem.WebApi.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : BaseController
    {
        public IMediator Mediator { get; set; }

        public ClientController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IRequestResponse<DetailsClientResult>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await this.Mediator.Send(new DetailsClientQuery(id));
            return this.ResponseModel(result);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IRequestResponse<CreateClientResult>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PostAsync(CreateClientCommand command)
        {
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IRequestResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PutAsync(Guid id, UpdateClientCommand command)
        {
            command.Id = id;
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(IRequestResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteClientCommand command)
        {
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(IRequestResponse<IEnumerable<ListClientResult>>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> ListAllAsync()
        {
            var result = await this.Mediator.Send(new ListAllClientQuery());
            return this.ResponseModel(result);
        }
    }
}
