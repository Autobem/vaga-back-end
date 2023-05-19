using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Application.Exceptions;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de veículos.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("vehicles")]
public class VehicleController : Controller
{
    /// <summary>
    /// O serviço para proprietários.
    /// </summary>
    private OwnerService ownerService;

    /// <summary>
    /// O serviço para cores.
    /// </summary>
    private VehicleColorService colorService;

    /// <summary>
    /// O serviço para modelos.
    /// </summary>
    private ModelService modelService;

    /// <summary>
    /// O serviço para combustíveis.
    /// </summary>
    private VehicleFuelService fuelService;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para veículos.</param>
    /// <param name="ownerService">O serviço para proprietários.</param>
    /// <param name="colorService">O serviço para cores.</param>
    /// <param name="modelService">O serviço para modelos.</param>
    /// <param name="fuelService">O serviço para combustíveis.</param>
    public VehicleController(
        VehicleService service,
        OwnerService ownerService,
        VehicleColorService colorService,
        ModelService modelService,
        VehicleFuelService fuelService
    ) : base(service)
    {
        this.ownerService = ownerService;
        this.colorService = colorService;
        this.modelService = modelService;
        this.fuelService = fuelService;
    }

    /// <summary>
    /// Remove determinado veículo.
    /// </summary>
    /// <param name="id">O ID do veículo.</param>
    /// <returns>Nenhum conteúdo.</returns>
    /// <response code="204">Retorna o corpo vazio.</response>
    [HttpDelete("{id}", Name = "RemoveVehicle")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await ((VehicleService) this.service).RemoveVehicleByID(id);

        return NoContent();
    }

    /// <summary>
    /// Resgata um determinado veículo.
    /// </summary>
    /// <param name="id">O ID do veículo.</param>
    /// <returns>Os dados do veículo.</returns>
    /// <response code="200">O veículo solicitado.</response>
    /// <response code="404">Se o veículo não for encontrado.</response>
    [HttpGet("{id}", Name = "RetrieveVehicle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        // Pega o veículo solicitado.
        var vehicle = await ((VehicleService) this.service).GetByID(id);

        return (vehicle is null)
            ? NotFound(new { Message = "Veículo não encontrado." })
            : Ok(vehicle);
    }

    /// <summary>
    /// Lista todos os veículos.
    /// </summary>
    /// <returns>Os veículos registrados.</returns>
    /// <response code="200">Retorna a lista de veículos.</response>
    [HttpGet(Name = "ListVehicles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Pega os veículos registrados.
        var vehicles = await ((VehicleService) this.service).GetAll();

        return Ok(vehicles);
    }

    /// <summary>
    /// Registra um novo veículo.
    /// </summary>
    /// <param name="owner">Os dados do novo veículo.</param>
    /// <returns>Uma mensagem.</returns>
    /// <response code="200">A mensagem de sucesso.</response>
    /// <response code="400">As mensagens de erro de validação.</response>
    /// <response code="422">As mensagens de erro de validação.</response>
    [HttpPost(Name = "RegisterVehicle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] VehicleData vehicle)
    {
        try
        {
            // Valida os dados da requisição.
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Verifica se já existe um veículo com a placa enviada.
            var existentVehicle = ((VehicleService) this.service).GetVehicleByPlate(
                vehicle.Plate
            );
            if (existentVehicle is not null) throw new ValidationException(
                "A placa deste veículo já está registrada."
            );

            // Realiza validações complementares da requisição.
            await this.ValidateData(vehicle);

            // Registra o novo veículo.
            await ((VehicleService) this.service).Create(vehicle);
        }
        catch (ValidationException exception)
        {
            return UnprocessableEntity(new
            {
                Message = exception.Message
            });
        }

        return Ok(new
        {
            Message = "Veículo registrado com sucesso!"
        });
    }

    /// <summary>
    /// Atualiza determinado veículo.
    /// </summary>
    /// <param name="owner">Os novos dados do veículo.</param>
    /// <param name="id">O ID do veículo.</param>
    /// <returns>Uma mensagem.</returns>
    /// <response code="200">A mensagem de sucesso.</response>
    /// <response code="400">As mensagens de erro de validação.</response>
    /// <response code="404">Se o veículo não for encontrado.</response>
    /// <response code="422">As mensagens de erro de validação.</response>
    [HttpPut("{id}", Name = "UpdateVehicle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Put(
        [FromBody] VehicleData vehicle,
        [FromRoute] Guid id
    )
    {
        try
        {
            var service = (VehicleService) this.service;
            // Verifica se o veículo existe.
            var existentVehicle = await service.GetByID(id);
            if (existentVehicle is null) return NotFound("Veículo não encontrado.");

            // Valida os dados da requisição.
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Realiza validações complementares da requisição.
            await this.ValidateData(vehicle);

            // Atualiza os dados do veículo.
            vehicle.Id = existentVehicle.Id;
            await service.UpdateVehicleByID(vehicle);
        }
        catch (ValidationException exception)
        {
            return UnprocessableEntity(new
            {
                Message = exception.Message
            });
        }

        return Ok(new
        {
            Message = "Veículo atualizado com sucesso!"
        });
    }

    /// <summary>
    /// Valida complementos da requisição.
    /// </summary>
    /// <param name="vehicle">Os dados da requisição.</param>
    /// <exception cref="ValidationException">Lançada quando o dado é inválido.</exception>
    /// <returns>A tarefa do método assíncrono.</returns>
    private async Task ValidateData(VehicleData vehicle)
    {
        // Verifica se o proprietário existe.
        var owner = await ((OwnerService) this.ownerService).GetEntity(
            vehicle.OwnerId
        );
        if (owner is null) throw new ValidationException(
            "ID do proprietário do veículo é inexistente."
        );

        // Verifica se a cor do veículo existe.
        var color = await ((VehicleColorService) this.colorService).GetEntity(
            vehicle.ColorId
        );
        if (color is null) throw new ValidationException(
            "ID da cor do veículo é inexistente."
        );

        // Verifica se o modelo do veículo existe.
        var model = await ((ModelService) this.modelService).GetEntity(
            vehicle.ModelId
        );
        if (model is null) throw new ValidationException(
            "ID do modelo do veículo é inexistente."
        );

        // Verifica se o combustível do veículo existe.
        var fuel = await ((VehicleFuelService) this.fuelService).GetEntity(
            vehicle.FuelId
        );
        if (fuel is null) throw new ValidationException(
            "ID do combustível do veículo é inexistente."
        );

        vehicle.Owner = owner;
        vehicle.Color = color;
        vehicle.Model = model;
        vehicle.Fuel = fuel;
    }
}