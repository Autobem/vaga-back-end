using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Base para todos os controladores.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public abstract class Controller : ControllerBase
{
    /// <summary>
    /// O serviço de domínio para lidar com a operação.
    /// </summary>
    protected Service service;

    /// <summary>
    /// Inicializa campos.
    /// </summary>
    /// <param name="service">O serviço de domínio.</param>
    public Controller(Service service)
    {
        this.service = service;
    }
}