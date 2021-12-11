using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileUserDTOToCommand : Profile
    {
        public ProfileUserDTOToCommand()
        {
            CreateMap<UserDTO, UserCreateCommand>();
            CreateMap<UserDTO, UserUpdateCommand>();

        }
    }
}
