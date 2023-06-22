using Domain.Contracts.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ownerService.Delete(id);
            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ownerService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _ownerService.GetById(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(OwnerModel owner)
        {
            return Created(nameof(OwnerModel), await _ownerService.Insert(owner));
        }

        [HttpPut]
        public async Task<IActionResult> Update(OwnerModel ownerModel)
        {
            await _ownerService.Update(ownerModel);
            return Accepted();
        }
    }
}