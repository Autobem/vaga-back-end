using Microsoft.AspNetCore.Mvc;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Application.Exceptions;
using VehicleRegistry.Domain.Services;

namespace VehicleRegistry.Application.Controllers;

/// <summary>
/// Controlador para as rotas de marcas de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
[ApiController]
[Route("brands")]
public class BrandController : Controller
{
    /// <summary>
    /// O serviço para modelos de veículos.
    /// </summary>
    private ModelService modelService;

    /// <summary>
    /// O serviço para tipos de veículos.
    /// </summary>
    private VehicleTypeService typeService;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="service">O serviço para marcas de veículos.</param>
    /// <param name="modelService">O serviço para modelos de veículos.</param>
    /// <param name="typeService">O serviço para tipos de veículos.</param>
    public BrandController(
        BrandService service,
        ModelService modelService,
        VehicleTypeService typeService
    ) : base(service)
    {
        this.modelService = modelService;
        this.typeService = typeService;
    }

    /// <summary>
    /// Lista todas as marcas de veículos.
    /// </summary>
    /// <returns>As marcas de veículos registradas.</returns>
    /// <response code="200">Retorna a lista de veículos.</response>
    [HttpGet(Name = "ListBrands")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        // Resgata as marcas registradas.
        List<BrandData> brands = await ((BrandService) this.service).GetAll();

        return Ok(brands);
    }

    /// <summary>
    /// Lista todos os modelos de veículos para a marca em questão.
    /// </summary>
    /// <param name="brandId">O ID da marca.</param>
    /// <returns>Os modelos de veículos.</returns>
    /// <response code="200">Retorna os modelos registrados.</response>
    [HttpGet("{brandId}/models", Name = "ListModels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListModels([FromRoute] Guid brandId)
    {
        // Resgata os modelos de determinada marca de veículo.
        List<ModelData> colors = await ((ModelService) this.modelService).GetModelsByBrand(
            brandId
        );

        return Ok(colors);
    }

    /// <summary>
    /// Registra um novo modelo de veículo.
    /// </summary>
    /// <param name="model">Os dados do modelo do veículo.</param>
    /// <param name="brandId">O ID da marca de veículos.</param>
    /// <returns>A mensagem de status.</returns>
    /// <response code="200">Retorna a mensagem de sucesso.</response>
    /// <response code="422">Se os dados forem inválidos.</response>
    [HttpPost("{brandId}/models", Name = "RegisterModel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> RegisterModel(
        [FromBody] ModelData model,
        [FromRoute] Guid brandId
    )
    {
        try {
            // Vincula o ID da marca aos dados do novo modelo de veículo.
            model.BrandId = brandId;

            // Verifica se o ID da marca existe.
            var brand = await ((BrandService) this.service).GetEntity(
                model.BrandId
            );
            if (brand is null) throw new ValidationException(
                "ID da marca do veículo é inexistente."
            );

            // Verifica se o tipo de veículo especificado existe.
            var type = await ((VehicleTypeService) this.typeService).GetEntity(
                model.TypeId
            );
            if (type is null) throw new ValidationException(
                "ID do tipo de veículo é inexistente."
            );

            // Registra o novo modelo de vículos.
            model.Brand = brand;
            model.Type = type;
            await this.modelService.Create(model);
        } catch (ValidationException exception) {
            return UnprocessableEntity(new {
                Message = exception.Message
            });
        }

        return Ok(new {
            Message = "Modelo registrado com sucesso!"
        });
    }
}