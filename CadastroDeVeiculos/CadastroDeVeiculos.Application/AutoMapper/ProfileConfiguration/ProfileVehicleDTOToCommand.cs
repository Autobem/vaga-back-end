using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileVehicleDTOToCommand : Profile
    {
        public ProfileVehicleDTOToCommand()
        {
            CreateMap<VehicleDTO, VehicleCreateCommand>();
            CreateMap<VehicleDTO, VehicleUpdateCommand>();
        }
    }
}
