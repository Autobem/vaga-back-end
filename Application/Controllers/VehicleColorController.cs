using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de cores de veículos.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("colors")]
public class VehicleColorController : Controller
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para cores de veículos.</param>
    public VehicleColorController(VehicleColorService service) : base(service)
    {}

    /// <summary>
    /// Lista todas as cores de veículos.
    /// </summary>
    /// <returns>As cores de veículos registradas.</returns>
    /// <response code="200">Retorna a lista de cores.</response>
    [HttpGet(Name = "ListVehicleColors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Resgata as cores.
        List<VehicleColorData> colors = await ((VehicleColorService) this.service).GetAll();

        return Ok(colors);
    }
}