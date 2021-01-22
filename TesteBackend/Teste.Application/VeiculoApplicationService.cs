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
    public class VeiculoApplicationService : IVeiculoApplicationService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        public VeiculoApplicationService(IVeiculoService veiculoService, IMapper mapper)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
        }

        public void Adicionar(VeiculoDto veiculoDto)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            _veiculoService.Adicionar(veiculo);
        }

        public void Atualizar(VeiculoDto veiculoDto)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            _veiculoService.Atualizar(veiculo);
        }

        public VeiculoDto ObterPorId(int id)
        {
            var veiculo = _veiculoService.ObterPorId(id);
            var veiculoDto = _mapper.Map<VeiculoDto>(veiculo);
            return veiculoDto;
        }

        public IEnumerable<VeiculoDto> ObterTodos()
        {
            var veiculos = _veiculoService.ObterTodos();
            var veiculosDto = _mapper.Map<IEnumerable<VeiculoDto>>(veiculos);
            return veiculosDto;
        }

        public void Remover(int id)
        {
            var veiculo = _veiculoService.ObterPorId(id);
            if(veiculo != null)
            {
                _veiculoService.Remover(id);
            }
        }
    }
}
