using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de combustíveis de veículos.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("fuels")]
public class VehicleFuelController : Controller
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para combustíveis.</param>
    public VehicleFuelController(VehicleFuelService service) : base(service)
    {}

    /// <summary>
    /// Lista todos os tipos de combustíveis de veículos.
    /// </summary>
    /// <returns>Os combustíveis registrados.</returns>
    /// <response code="200">Retorna a lista de combustíveis.</response>
    [HttpGet(Name = "ListVehicleFuels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Pega os combustíveis registrados.
        List<VehicleFuelData> fuels = await ((VehicleFuelService) this.service).GetAll();

        return Ok(fuels);
    }
}