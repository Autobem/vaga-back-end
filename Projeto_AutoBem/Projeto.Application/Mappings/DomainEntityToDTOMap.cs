using AutoMapper;
using Projeto.Application.DTOs;
using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto.Application.Mappings
{
    public class DomainEntityToDTOMap : Profile
    {
        public DomainEntityToDTOMap()
        {
            CreateMap<Proprietario, ProprietarioDTO>()
               .AfterMap((src, dest) => {
                  dest.IdProprietario = src.IdProprietario.ToString();
               });

            CreateMap<Veiculo, VeiculoDTO>()
              .AfterMap((src, dest) => {
                  dest.IdVeiculo = src.IdVeiculo.ToString();
              });

            CreateMap<Usuario, UsuarioDTO>()
              .AfterMap((src, dest) => {
                  dest.IdUsuario = src.IdUsuario.ToString();
              });
        }
    }
}
