using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;

using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de proprietários.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("owners")]
public class OwnerController : Controller
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para proprietários.</param>
    public OwnerController(OwnerService service) : base(service)
    {}

    /// <summary>
    /// Remove determinado proprietário.
    /// </summary>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>Nenhum conteúdo.</returns>
    /// <response code="204">Retorna o corpo vazio.</response>
    [HttpDelete("{id}", Name = "RemoveOwner")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        // Remove o proprietário.
        await ((OwnerService) this.service).RemoveOwnerByID(id);

        return NoContent();
    }

    /// <summary>
    /// Resgata um determinado proprietário.
    /// </summary>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>Os dados do proprietário.</returns>
    /// <response code="200">O proprietário solicitado.</response>
    /// <response code="404">Se o proprietário não for encontrado.</response>
    [HttpGet("{id}", Name = "RetrieveOwner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        // Pega o proprietário solicitado.
        var owner = await ((OwnerService) this.service).GetByID(id);

        return (owner is null)
            ? NotFound(new { Message = "Proprietário não encontrado." })
            : Ok(owner);
    }

    /// <summary>
    /// Lista todos os proprietários.
    /// </summary>
    /// <returns>Os proprietários de veículos registrados.</returns>
    /// <response code="200">Retorna a lista de proprietários.</response>
    [HttpGet(Name = "ListOwners")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Pega os proprietários registrados.
        List<OwnerData> owners = await ((OwnerService) this.service).GetAll();

        return Ok(owners);
    }

    /// <summary>
    /// Registra um novo proprietário.
    /// </summary>
    /// <param name="owner">Os dados do novo proprietário.</param>
    /// <returns>Uma mensagem.</returns>
    /// <response code="200">A mensagem de sucesso.</response>
    /// <response code="400">As mensagens de erro de validação.</response>
    [HttpPost(Name = "RegisterOwner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] OwnerData owner)
    {
        // Valida os dados da requisição.
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Registra o novo proprietário.
        await ((OwnerService) this.service).Create(owner);

        return Ok(new {
            Message = "Proprietário registrado com sucesso!"
        });
    }

    /// <summary>
    /// Atualiza determinado proprietário.
    /// </summary>
    /// <param name="owner">Os novos dados do proprietário.</param>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>Uma mensagem.</returns>
    /// <response code="200">A mensagem de sucesso.</response>
    /// <response code="404">Se o proprietário não for encontrado.</response>
    /// <response code="400">As mensagens de erro de validação.</response>
    [HttpPut("{id}", Name = "UpdateOwner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(
        [FromBody] OwnerData owner,
        [FromRoute] Guid id
    )
    {
        var service = (OwnerService) this.service;
        // Verifica se o proprietário existe.
        var existentOwner = await service.GetByID(id);
        if (existentOwner is null) return NotFound(
            "Proprietário não encontrado."
        );

        // Valida os dados da requisição.
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Atualiza os dados.
        owner.Id = existentOwner.Id;
        await service.UpdateOwnerByID(owner);

        return Ok(new
        {
            Message = "Proprietário atualizado com sucesso!"
        });
    }
}