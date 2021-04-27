using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Service.Validators;
using System;


namespace Model.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        private IBaseService<Owner> _baseOwnerService;

        public OwnerController(IBaseService<Owner> baseOwnerService)
        {
            _baseOwnerService = baseOwnerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Owner owner)
        {
            if (owner == null)
                return NotFound();

            return Execute(() => _baseOwnerService.Add<OwnerValidator>(owner).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Owner owner)
        {
            if (owner == null)
                return NotFound();

            return Execute(() => _baseOwnerService.Update<OwnerValidator>(owner));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseOwnerService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseOwnerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseOwnerService.GetById(id));
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
