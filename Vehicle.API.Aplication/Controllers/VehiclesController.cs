using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Context;
using Vehicles.API.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicles.API.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly MyContext _context;

        public VehiclesController(MyContext context)
        {
            this._context = context;
        }
        // GET: api/<VehiclesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            return await _context.Vehicles.ToListAsync();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Get(Guid id)
        {
            var result = await _context.Vehicles.FindAsync(id);
            if (result == null) return NotFound();

            return result;
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Add(vehicle);
                var result = await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> Put(Guid id, Vehicle vehicle)
        {
            if (id != vehicle.Id) return BadRequest();

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _context.Vehicles.FindAsync(id);
            if (result == null) return NotFound(false);

            try
            {
                _context.Vehicles.Remove(result);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
    }
}
