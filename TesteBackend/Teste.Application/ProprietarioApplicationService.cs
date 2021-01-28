using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Application.Dtos;
using Teste.Application.Interfaces;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;

namespace Teste.Application
{
    public class ProprietarioApplicationService : IProprietarioApplicationService
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMapper _mapper;

        public ProprietarioApplicationService(IProprietarioService proprietarioService,
            IProprietarioRepository proprietarioRepository,
            IMapper mapper)
        {
            _proprietarioService = proprietarioService;
            _proprietarioRepository = proprietarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(ProprietarioDto proprietarioDto)
        {
            var proprietario = _mapper.Map<Proprietario>(proprietarioDto);
            return await _proprietarioService.Adicionar(proprietario);
        }

        public async Task<bool> Atualizar(ProprietarioDto proprietarioDto)
        {
            var proprietario = _mapper.Map<Proprietario>(proprietarioDto);
            return await _proprietarioService.Atualizar(proprietario);
        }

        public async Task<ProprietarioDto> ObterPorId(int id)
        {
            var proprietario = await _proprietarioRepository.ObterPorId(id);
            var proprietarioDto = _mapper.Map<ProprietarioDto>(proprietario);
            return proprietarioDto;
        }

        public async Task<IEnumerable<ProprietarioDto>> ObterTodos()
        {
            var proprietarios = await _proprietarioRepository.ObterTodos();
            var proprietariosDto = _mapper.Map<IEnumerable<ProprietarioDto>>(proprietarios);
            return proprietariosDto;
        }

        public async Task<bool> Remover(int id)
        {
            return await _proprietarioService.Remover(id);
        }
    }
}
