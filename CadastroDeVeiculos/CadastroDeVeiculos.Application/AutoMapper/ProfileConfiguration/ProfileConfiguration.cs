using AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<User, ClientDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
