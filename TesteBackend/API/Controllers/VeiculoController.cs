using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Dtos;
using Teste.Application.Extensions;
using Teste.Application.Interfaces;
using Teste.Domain.Core.Interfaces.Services;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class VeiculoController : MainController
    {
        private readonly IVeiculoApplicationService _veiculoApplicationService;

        public VeiculoController(IVeiculoApplicationService veiculoApplicationService,
            INotificador notificador) : base(notificador)
        {
            _veiculoApplicationService = veiculoApplicationService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<VeiculoDto>> Obtertodos()
        {
            return await _veiculoApplicationService.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VeiculoDto>> ObterPorId(int id)
        {
            var veiculoDto = await _veiculoApplicationService.ObterPorId(id);
            if (veiculoDto == null) return NotFound();
            return veiculoDto;
        }

        [ClaimsAuthorize("Gerente", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VeiculoDto>> Adicionar(VeiculoDto veiculoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _veiculoApplicationService.Adicionar(veiculoDto);
            return CustomResponse(veiculoDto);
        }

        [ClaimsAuthorize("Gerente", "Atualizar")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VeiculoDto>> Atualizar(int id, VeiculoDto veiculoDto)
        {
            if (id != veiculoDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(veiculoDto);
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _veiculoApplicationService.Atualizar(veiculoDto);
            return CustomResponse(veiculoDto);
        }

        [ClaimsAuthorize("Gerente", "Remover")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VeiculoDto>> Remover(int id)
        {
            var veiculoDto = await _veiculoApplicationService.ObterPorId(id);
            if (veiculoDto == null) return NotFound();
            await _veiculoApplicationService.Remover(id);
            return CustomResponse(veiculoDto);
        }
    }
}
