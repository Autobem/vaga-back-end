using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.DTOs;
using Projeto.Application.Models.Proprietarios;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Services;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class ProprietarioApplicationService : IProprietarioApplicationService
    {
        private readonly IProprietarioDomainService proprietarioDomainService;
        private readonly IMapper mapper;

        public ProprietarioApplicationService(IProprietarioDomainService proprietarioDomainService, IMapper mapper)
        {
            this.proprietarioDomainService = proprietarioDomainService;
            this.mapper = mapper;
        }

        public void Create(ProprietarioCadastroModel model)
        {
            var proprietario = mapper.Map<Proprietario>(model);
            proprietarioDomainService.Create(proprietario);
        }

        public void Update(ProprietarioEdicaoModel model)
        {
            var categoria = mapper.Map<Proprietario>(model);
            proprietarioDomainService.Update(categoria);
        }

        public void Delete(ProprietarioExclusaoModel model)
        {
            var id = int.Parse(model.IdProprietario);
            var categoria = proprietarioDomainService.GetById(id);

            proprietarioDomainService.Delete(categoria);
        }

        public List<ProprietarioDTO> GetAll()
        {
            return mapper.Map<List<ProprietarioDTO>>
               (proprietarioDomainService.GetAll());
        }

        public ProprietarioDTO GetById(string id)
        {
            return mapper.Map<ProprietarioDTO>
               (proprietarioDomainService.GetById(int.Parse(id)));
        }
       
    }
}
