using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Client, UserDTO>().ReverseMap();
        }
    }
}
