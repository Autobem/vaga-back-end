using AutoBem.Application.Vehicles.Commands.Create;
using AutoBem.Application.Vehicles.Commands.Delete;
using AutoBem.Application.Vehicles.Commands.Update;
using AutoBem.Application.Vehicles.Queries.Details;
using AutoBem.Application.Vehicles.Queries.ListAll;
using BuildingBlocks.Mediator.Requests;
using BuildingBlocks.WebApi;
using BuildingBlocks.WebApi.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoBem.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : BaseController
    {
        public IMediator Mediator { get; set; }

        public VehicleController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IRequestResponse<DetailsVehicleResult>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await this.Mediator.Send(new DetailsVehicleQuery(id));
            return this.ResponseModel(result);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IRequestResponse<CreateVehicleResult>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PostAsync(CreateVehicleCommand command)
        {
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IRequestResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PutAsync(Guid id, UpdateVehicleCommand command)
        {
            command.Id = id;
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(IRequestResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteVehicleCommand command)
        {
            var result = await this.Mediator.Send(command);
            return this.ResponseModel(result);
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(IRequestResponse<IEnumerable<ListVehicleResult>>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> ListAllAsync()
        {
            var result = await this.Mediator.Send(new ListAllVehicleQuery());
            return this.ResponseModel(result);
        }
    }
}
