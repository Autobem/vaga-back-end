using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de tipos de veículos.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("types")]
public class VehicleTypeController : Controller
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para tipos de veículos.</param>
    public VehicleTypeController(VehicleTypeService service) : base(service)
    {}

    /// <summary>
    /// Lista todos os tipos de veículos.
    /// </summary>
    /// <returns>Os tipos de veículos registrados.</returns>
    /// <response code="200">Retorna a lista de tipos de veículos.</response>
    [HttpGet(Name = "ListVehicleTypes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Pega os tipos de veículos.
        List<VehicleTypeData> types = await ((VehicleTypeService) this.service).GetAll();

        return Ok(types);
    }
}