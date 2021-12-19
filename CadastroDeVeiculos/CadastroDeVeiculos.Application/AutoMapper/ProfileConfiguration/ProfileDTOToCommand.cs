using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands;
using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands;
using CadastroDeVeiculos.Domain.ValueObject;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileDTOToCommand : Profile
    {
        public ProfileDTOToCommand()
        {
            CreateMap<ClientDTO, ClientCreateCommand>().ReverseMap();
            CreateMap<ClientDTO, ClientUpdateCommand>();

            CreateMap<VehicleDTO, VehicleCreateCommand>().ReverseMap();
            CreateMap<VehicleDTO, VehicleUpdateCommand>();
        }
    }
}
