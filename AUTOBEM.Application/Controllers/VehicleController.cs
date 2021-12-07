using AUTOBEM.Domain.Entities;
using AUTOBEM.Domain.Interfaces;
using AUTOBEM.Application.Models;
using AUTOBEM.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AUTOBEM.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IBaseService<Vehicle> _baseVehicleService;

        public VehicleController(IBaseService<Vehicle> baseVehicleService)
        {
            _baseVehicleService = baseVehicleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVehicleModel vehicle)
        {
            if (vehicle == null)
                return NotFound();

            return Execute(() => _baseVehicleService.Add<CreateVehicleModel, VehicleModel, VehicleValidator>(vehicle));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateVehicleModel vehicle)
        {
            if (vehicle == null)
                return NotFound();

            return Execute(() => _baseVehicleService.Update<UpdateVehicleModel, VehicleModel, VehicleValidator>(vehicle));
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
            return Execute(() => _baseVehicleService.Get<VehicleModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseVehicleService.GetById<VehicleModel>(id));
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
