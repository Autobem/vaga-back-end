using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Dtos;
using Teste.Application.Interfaces;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;

namespace Teste.Application
{
    public class ProprietarioApplicationService : IProprietarioApplicationService
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IMapper _mapper;

        public ProprietarioApplicationService(IProprietarioService proprietarioService, IMapper mapper)
        {
            _proprietarioService = proprietarioService;
            _mapper = mapper;
        }

        public void Adicionar(ProprietarioDto proprietarioDto)
        {
            var proprietario = _mapper.Map<Proprietario>(proprietarioDto);
            _proprietarioService.Adicionar(proprietario);
        }

        public void Atualizar(ProprietarioDto proprietarioDto)
        {
            var proprietario = _mapper.Map<Proprietario>(proprietarioDto);
            _proprietarioService.Atualizar(proprietario);
        }

        public ProprietarioDto ObterPorId(int id)
        {
            var proprietario = _proprietarioService.ObterPorId(id);
            var proprietarioDto = _mapper.Map<ProprietarioDto>(proprietario);
            return proprietarioDto;
        }

        public IEnumerable<ProprietarioDto> ObterTodos()
        {
            var proprietarios = _proprietarioService.ObterTodos();
            var proprietariosDto = _mapper.Map<IEnumerable<ProprietarioDto>>(proprietarios);
            return proprietariosDto;
        }

        public void Remover(int id)
        {
             var proprietario = _proprietarioService.ObterPorId(id);
            if (proprietario != null)
            {
                _proprietarioService.Remover(id);
            }
        }
    }
}
