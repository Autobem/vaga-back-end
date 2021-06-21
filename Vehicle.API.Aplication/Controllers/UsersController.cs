using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.User;
using Vehicles.API.Domain.Interfaces.Services.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicles.API.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService _service)
        {
            this._service = _service;
        }
        // GET: api/<UsersController>
        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
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

        // GET api/<UsersController>/5
        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                var user = await _service.Get(id);
                return user == null ? NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST api/<UsersController>
        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDtoCreate user)
        {
            try
            {
                return Ok(await _service.Post(user));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // PUT api/<UsersController>/5
        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult<UserDto>> Put([FromBody] UserDto user)
        {
            //if (id != vehicle.Id) return BadRequest();

            try
            {
                var result = await _service.Put(user);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // DELETE api/<UsersController>/5
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
