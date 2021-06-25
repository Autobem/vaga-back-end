using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Context;
using Vehicles.API.Domain.Dtos.Owner;
using Vehicles.API.Domain.Interfaces.Services.Owner;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicles.API.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _service;
        private readonly MyContext _context;

        public OwnersController(IOwnerService service, MyContext context)
        {
            this._service = service;
            this._context = context;
        }
        // GET: api/<OwnerController>
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAll()
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

        // GET api/<OwnerController>/5
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> Get(Guid id)
        {
            try
            {
                var owner = await _service.Get(id);
                return owner == null ? NotFound() : Ok(owner);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST api/<OwnerController>
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<OwnerDto>> Post([FromBody] OwnerDtoCreate owner)
        {            
            try
            {
                return Ok(await _service.Post(owner));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // PUT api/<OwnerController>/5
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult<OwnerDto>> Put([FromBody] OwnerDtoUpdate owner)
        {
            //if (id != vehicle.Id) return BadRequest();

            try
            {
                var result = await _service.Put(owner);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // DELETE api/<OwnerController>/5
        [Authorize("Bearer")]
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
