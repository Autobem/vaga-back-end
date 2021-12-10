using Projeto.Application.DTOs;
using Projeto.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        void Create(UsuarioCadastroModel model);
        void Update(UsuarioEdicaoModel model);
        void Delete(UsuarioExclusaoModel model);
        List<UsuarioDTO> GetAll();
        UsuarioDTO GetById(string id);
        UsuarioDTO GetByEmailAndSenha(UsuarioAutenticacaoModel model);
        UsuarioDTO GetByEmail(string email);
    }
}
