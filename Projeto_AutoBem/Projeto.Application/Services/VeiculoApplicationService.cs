using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.DTOs;
using Projeto.Application.Models.Veiculos;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Services;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class VeiculoApplicationService : IVeiculoApplicationService
    {
        private readonly IVeiculoDomainService veiculoDomainService;
        private readonly IMapper mapper;

        public VeiculoApplicationService(IVeiculoDomainService proprietarioDomainService, IMapper mapper)
        {
            this.veiculoDomainService = proprietarioDomainService;
            this.mapper = mapper;
        }

        public void Create(VeiculoCadastroModel model)
        {
            var veiculo = mapper.Map<Veiculo>(model);
            veiculoDomainService.Create(veiculo);
        }

        public void Update(VeiculoEdicaoModel model)
        {
            var veiculo = mapper.Map<Veiculo>(model);
            veiculoDomainService.Update(veiculo);
        }

        public void Delete(VeiculoExclusaoModel model)
        {
            var id = int.Parse(model.IdVeiculo);
            var categoria = veiculoDomainService.GetById(id);

            veiculoDomainService.Delete(categoria);
        }

        public List<VeiculoDTO> GetAll()
        {
            return mapper.Map<List<VeiculoDTO>>
               (veiculoDomainService.GetAll());
        }

        public VeiculoDTO GetById(string id)
        {
            return mapper.Map<VeiculoDTO>
              (veiculoDomainService.GetById(int.Parse(id)));
        }

      
    }
}
