using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Context;
using Vehicles.API.Domain.Dtos.Owner;
using Vehicles.API.Domain.Dtos.Vehicle;
using Vehicles.API.Domain.Entities;
using Vehicles.API.Domain.Interfaces.Services.Owner;
using Vehicles.API.Domain.Interfaces.Services.Vehicle;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicles.API.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleService service, MyContext context, IMapper mapper)
        {
            this._service = service;
            this._context = context;
            this._mapper = mapper;
        }
        // GET: api/<VehiclesController>
        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET api/<VehiclesController>/5
        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> Get(Guid id)
        {
            try
            {
                var vehicle = await _service.Get(id);
                return vehicle == null ? NotFound() : Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST api/<VehiclesController>
        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> Post([FromBody] VehicleDtoCreate vehicle)
        {            
            if (vehicle.OwnerId == null && vehicle.Owner == null) return StatusCode(403, "OwnerId or Owner are required!");    
            if(vehicle.OwnerId != null && vehicle.Owner != null) return StatusCode(403, "Only OwnerId or Owner must be filled!");

            try
            {
                if (vehicle.Owner != null) await _context.Owners.AddAsync(_mapper.Map<Owner>(vehicle.Owner));
                return Ok(await _service.Post(vehicle));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            } 
        }

        // PUT api/<VehiclesController>/5
        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult<VehicleDto>> Put([FromBody] VehicleDtoUpdate vehicle)
        {
            //if (id != vehicle.Id) return BadRequest();

            try
            {
                var result = await _service.Put(vehicle);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // DELETE api/<VehiclesController>/5
        //[Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
