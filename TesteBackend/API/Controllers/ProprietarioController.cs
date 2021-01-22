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
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioApplicationService _proprietarioApplicationService;

        public ProprietarioController(IProprietarioApplicationService proprietarioApplicationService)
        {
            _proprietarioApplicationService = proprietarioApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProprietarioDto>> Obtertodos()
        {
            var proprietariosDto = _proprietarioApplicationService.ObterTodos();
            return Ok(proprietariosDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProprietarioDto> ObterPorId(int id)
        {
            var proprietarioDto = _proprietarioApplicationService.ObterPorId(id);
            if (proprietarioDto == null) return NotFound();
            return Ok(proprietarioDto);
        }

        [HttpPost]
        public ActionResult<ProprietarioDto> Adicionar(ProprietarioDto proprietarioDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _proprietarioApplicationService.Adicionar(proprietarioDto);
            //TODO: validar se já existe cadastro com o mesmo CPF.
            return Ok(proprietarioDto);
        }

        [HttpPut]
        public ActionResult<ProprietarioDto> Atualizar(ProprietarioDto proprietarioDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _proprietarioApplicationService.Atualizar(proprietarioDto);
            return Ok(proprietarioDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProprietarioDto> Remover(int id)
        {
            var proprietarioDto = _proprietarioApplicationService.ObterPorId(id);
            if (proprietarioDto == null) return NotFound();
            _proprietarioApplicationService.Remover(id);
            return Ok(proprietarioDto);
        }
    }
}
