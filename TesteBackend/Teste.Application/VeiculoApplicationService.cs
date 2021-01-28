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
    public class VeiculoApplicationService : IVeiculoApplicationService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoApplicationService(IVeiculoService veiculoService,
            IVeiculoRepository veiculoRepository,
            IMapper mapper)
        {
            _veiculoService = veiculoService;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(VeiculoDto veiculoDto)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            return await _veiculoService.Adicionar(veiculo);
        }

        public async Task<bool> Atualizar(VeiculoDto veiculoDto)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            return await _veiculoService.Atualizar(veiculo);
        }

        public async Task<VeiculoDto> ObterPorId(int id)
        {
            var veiculo = await _veiculoRepository.ObterPorId(id);
            var veiculoDto = _mapper.Map<VeiculoDto>(veiculo);
            return veiculoDto;
        }

        public async Task<IEnumerable<VeiculoDto>> ObterTodos()
        {
            var veiculos = await _veiculoRepository.ObterTodos();
            var veiculosDto = _mapper.Map<IEnumerable<VeiculoDto>>(veiculos);
            return veiculosDto;
        }

        public async Task<bool> Remover(int id)
        {
            return await _veiculoService.Remover(id);
        }
    }
}
