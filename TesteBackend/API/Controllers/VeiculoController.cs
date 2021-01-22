using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Dtos;
using Teste.Application.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoApplicationService _veiculoApplicationService;

        public VeiculoController(IVeiculoApplicationService veiculoApplicationService)
        {
            _veiculoApplicationService = veiculoApplicationService;
        }

        //TODO: implementar respostas personalizadas para cada Action.

        [HttpGet]
        public ActionResult<IEnumerable<VeiculoDto>> Obtertodos()
        {
            var veiculosDto = _veiculoApplicationService.ObterTodos();
            return Ok(veiculosDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<VeiculoDto> ObterPorId(int id)
        {
            var veiculoDto = _veiculoApplicationService.ObterPorId(id);
            if (veiculoDto == null) return NotFound();
            return Ok(veiculoDto);
        }

        [HttpPost]
        public ActionResult<VeiculoDto> Adicionar(VeiculoDto veiculoDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _veiculoApplicationService.Adicionar(veiculoDto);
            return Ok(veiculoDto);
        }

        [HttpPut]
        public ActionResult<VeiculoDto> Atualizar(VeiculoDto veiculoDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _veiculoApplicationService.Atualizar(veiculoDto);
            return Ok(veiculoDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<VeiculoDto> Remover(int id)
        {
            var veiculoDto = _veiculoApplicationService.ObterPorId(id);
            if (veiculoDto == null) return NotFound();
            _veiculoApplicationService.Remover(id);
            return Ok(veiculoDto);
        }
    }
}
