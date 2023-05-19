using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de autenticação.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("auth")]
public class AuthController : Controller
{
    /// <summary>
    /// O gerenciador de usuários.
    /// </summary>
    private UserManager<User> userManager;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para autenticação.</param>
    /// <param name="userManager">O gerenciador de usuários.</param>
    public AuthController(
        AuthService service,
        UserManager<User> userManager
    ) : base(service)
    {
        this.userManager = userManager;
    }

    /// <summary>
    /// Realiza a autenticação do usuário.
    /// </summary>
    /// <param name="credentials">As credenciais da autenticação.</param>
    /// <returns>O novo token de acesso.</returns>
    /// <response code="200">Retorna o token gerado.</response>
    /// <response code="401">Se as credenciais forem inválidas.</response>
    [AllowAnonymous]
    [HttpPost(Name = "GenerateAccessToken")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] LoginData credentials)
    {
        IActionResult response = this.Unauthorized(new {
            message = "Credenciais inválidas."
        });

        // Resgata um novo token de acesso, baseado nas credenciais forncidas
        // pelo usuário.
        string token = await ((AuthService) this.service).Authenticate(
            credentials
        );
        // Verifica se um token válido foi gerado.
        if (!string.IsNullOrEmpty(token)) response = Ok(new {
            token
        });

        return response;
    }
}
