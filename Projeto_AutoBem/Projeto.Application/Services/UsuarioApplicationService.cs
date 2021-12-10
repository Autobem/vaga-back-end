using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.DTOs;
using Projeto.Application.Models.Usuarios;
using Projeto.Domain.Aggregates.Usuarios.Contracts.Services;
using Projeto.Domain.Aggregates.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService usuarioDomainService;
        private readonly IMapper mapper;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            this.usuarioDomainService = usuarioDomainService;
            this.mapper = mapper;
        }

        public void Create(UsuarioCadastroModel model)
        {
            var usuario = mapper.Map<Usuario>(model);
            usuarioDomainService.Create(usuario);
        }

        public void Update(UsuarioEdicaoModel model)
        {
            var usuario = mapper.Map<Usuario>(model);
            usuarioDomainService.Update(usuario);
        }

        public void Delete(UsuarioExclusaoModel model)
        {
            var idUsuario = int.Parse(model.IdUsuario);
            var usuario = usuarioDomainService.GetById(idUsuario);

            usuarioDomainService.Delete(usuario);
        }

        public List<UsuarioDTO> GetAll()
        {
            return mapper.Map<List<UsuarioDTO>>
                (usuarioDomainService.GetAll());
        }

        public UsuarioDTO GetById(string id)
        {
            return mapper.Map<UsuarioDTO>
                (usuarioDomainService.GetById(int.Parse(id)));
        }

        public UsuarioDTO GetByEmailAndSenha(UsuarioAutenticacaoModel model)
        {
            return mapper.Map<UsuarioDTO>
                (usuarioDomainService.GetByEmailAndSenha
                (model.Email, model.Senha));
        }

        public UsuarioDTO GetByEmail(string email)
        {
            return mapper.Map<UsuarioDTO>
                (usuarioDomainService.GetByEmail(email));
        }
    }
}
