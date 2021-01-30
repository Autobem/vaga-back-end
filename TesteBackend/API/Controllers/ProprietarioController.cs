﻿using System.Collections.Generic;
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
    public class ProprietarioController : MainController
    {
        private readonly IProprietarioApplicationService _proprietarioApplicationService;

        public ProprietarioController(IProprietarioApplicationService proprietarioApplicationService,
            INotificador notificador) : base(notificador)
        {
            _proprietarioApplicationService = proprietarioApplicationService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProprietarioDto>> Obtertodos()
        {
            return await _proprietarioApplicationService.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProprietarioDto>> ObterPorId(int id)
        {
            var proprietarioDto = await _proprietarioApplicationService.ObterPorId(id);
            if (proprietarioDto == null) return NotFound();
            return proprietarioDto;
        }

        [ClaimsAuthorize("Gerente", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ProprietarioDto>> Adicionar(ProprietarioDto proprietarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _proprietarioApplicationService.Adicionar(proprietarioDto);
            return CustomResponse(proprietarioDto);
        }

        [ClaimsAuthorize("Gerente", "Atualizar")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProprietarioDto>> Atualizar(int id, ProprietarioDto proprietarioDto)
        {
            if (id != proprietarioDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(proprietarioDto);
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _proprietarioApplicationService.Atualizar(proprietarioDto);
            return CustomResponse(proprietarioDto);
        }

        [ClaimsAuthorize("Gerente", "Remover")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProprietarioDto>> Remover(int id)
        {
            var proprietarioDto = await _proprietarioApplicationService.ObterPorId(id);
            if (proprietarioDto == null) return NotFound();
            await _proprietarioApplicationService.Remover(id);
            return CustomResponse(proprietarioDto);
        }
    }
}
