using Projeto.Application.DTOs;
using Projeto.Application.Models.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IVeiculoApplicationService
    {
        void Create(VeiculoCadastroModel model);
        void Update(VeiculoEdicaoModel model);
        void Delete(VeiculoExclusaoModel model);
        List<VeiculoDTO> GetAll();
        VeiculoDTO GetById(string id);
    }
}
