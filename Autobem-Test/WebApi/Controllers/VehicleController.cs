using Domain.Contracts.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _vehicleService.Delete(id);
        return Accepted();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _vehicleService.Get());
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _vehicleService.GetById(id);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Insert(VehicleModel vehicle)
    {
        return Created(nameof(VehicleModel), await _vehicleService.Insert(vehicle));
    }

    [HttpPut]
    public async Task<IActionResult> Update(VehicleModel vehicle)
    {
        await _vehicleService.Update(vehicle);
        return Accepted();
    }
}