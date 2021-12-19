using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.ValueObject;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileObjectToDTO : Profile
    {
        public ProfileObjectToDTO()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Name, NameDTO>().ReverseMap();
        }
    }
}
