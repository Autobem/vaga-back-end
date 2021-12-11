using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileClientDTOToCommand : Profile
    {
        public ProfileClientDTOToCommand()
        {
            CreateMap<ClientDTO, ClientCreateCommand>();
            CreateMap<ClientDTO, ClientUpdateCommand>();
        }
    }
}
