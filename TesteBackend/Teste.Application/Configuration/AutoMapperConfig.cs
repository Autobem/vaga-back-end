using AutoMapper;

using Teste.Application.Dtos;
using Teste.Domain.Entities;

namespace Teste.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Proprietario, ProprietarioDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(x => x.NomeCompleto))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.VeiculosDto, opt => opt.MapFrom(x => x.Veiculos));
            
            CreateMap<ProprietarioDto, Proprietario>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(x => x.NomeCompleto))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.Veiculos, opt => opt.MapFrom(x => x.VeiculosDto));

            CreateMap<Veiculo, VeiculoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(x => x.Marca))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(x => x.Modelo))
                .ForMember(dest => dest.Cor, opt => opt.MapFrom(x => x.Cor))
                .ForMember(dest => dest.ProprietarioDtoId, opt => opt.MapFrom(x => x.ProprietarioId))
                .ForMember(dest => dest.ProprietarioDto, opt => opt.MapFrom(x => x.Proprietario));

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(x => x.Marca))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(x => x.Modelo))
                .ForMember(dest => dest.Cor, opt => opt.MapFrom(x => x.Cor))
                .ForMember(dest => dest.ProprietarioId, opt => opt.MapFrom(x => x.ProprietarioDtoId))
                .ForMember(dest => dest.Proprietario, opt => opt.MapFrom(x => x.ProprietarioDto));
        }
    }
}
