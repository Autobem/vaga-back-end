using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private IBaseService<Vehicle> _baseVehicleService;
        public VehicleController(IBaseService<Vehicle> baseVehicleService)
        {
            _baseVehicleService = baseVehicleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return NotFound();

            return Execute(() => _baseVehicleService.Add<VehicleValidator>(vehicle).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return NotFound();

            return Execute(() => _baseVehicleService.Update<VehicleValidator>(vehicle));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseVehicleService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseVehicleService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseVehicleService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
