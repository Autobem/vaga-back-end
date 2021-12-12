using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileObjectToDTO : Profile
    {
        public ProfileObjectToDTO()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        }
    }
}
