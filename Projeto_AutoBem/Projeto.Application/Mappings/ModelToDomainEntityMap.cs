using AutoMapper;
using Projeto.Application.Models.Proprietarios;
using Projeto.Application.Models.Usuarios;
using Projeto.Application.Models.Veiculos;
using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Mappings
{
    public class ModelToDomainEntityMap : Profile
    {
        public ModelToDomainEntityMap()
        {
            #region Proprietarios

            CreateMap<ProprietarioCadastroModel, Proprietario>()
               .AfterMap((src, dest) => {
                   //dest.Id = Guid.NewGuid();
               });

            CreateMap<ProprietarioEdicaoModel, Proprietario>()
               .AfterMap((src, dest) => {
                   dest.IdProprietario = int.Parse(src.IdProprietario);
               });

            #endregion


            #region Veiculos

            CreateMap<VeiculoCadastroModel, Veiculo>()
               .AfterMap((src, dest) => {
                   dest.IdProprietario = int.Parse(src.IdProprietario);
               });

            CreateMap<VeiculoEdicaoModel, Veiculo>()
               .AfterMap((src, dest) => {
                   dest.IdVeiculo = int.Parse(src.IdVeiculo);
                   dest.IdProprietario = int.Parse(src.IdProprietario);
               });

            #endregion

            #region Usuarios

            CreateMap<UsuarioCadastroModel, Usuario>()
              .AfterMap((src, dest) => {               
                  dest.DataCriacao = DateTime.Now;
              });

            CreateMap<UsuarioEdicaoModel, Usuario>()
              .AfterMap((src, dest) => {
                  dest.IdUsuario = int.Parse(src.IdUsuario);
                  dest.DataCriacao = DateTime.Now;
              });

            #endregion
        }
    }
}
