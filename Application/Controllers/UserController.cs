using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de usuários.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("users")]
public class UserController : Controller
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para usuários.</param>
    public UserController(UserService service) : base(service)
    {}

    /// <summary>
    /// Registra um novo usuário.
    /// </summary>
    /// <param name="user">Os dados do novo usuário.</param>
    /// <returns>Uma mensagem.</returns>
    /// <response code="200">A mensagem de sucesso.</response>
    /// <response code="422">As mensagens de erro de validação.</response>
    [AllowAnonymous]
    [HttpPost(Name = "RegisterUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] UserData user)
    {
        // Registra o usuário.
        var result = await ((UserService) this.service).CreateUser(user);
        // Verifica se foi inserido com sucesso.
        if (result.Succeeded) {
            return Ok(new {
                Message = "Usuário criado com sucesso."
            });
        }

        return UnprocessableEntity(result.Errors);
    }
}