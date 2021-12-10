using Projeto.Application.DTOs;
using Projeto.Application.Models.Proprietarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IProprietarioApplicationService
    {
        void Create(ProprietarioCadastroModel model);
        void Update(ProprietarioEdicaoModel model);
        void Delete(ProprietarioExclusaoModel model);
        List<ProprietarioDTO> GetAll();
        ProprietarioDTO GetById(string id);
    }
}
