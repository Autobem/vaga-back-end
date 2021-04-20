using Api.Domain.DTO.Pessoa;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.InfraCrossCutting.Mappings
{
    public class EntityParaDTOProfile : Profile
    {
        public EntityParaDTOProfile()
        {
            //mapeamento entidades para dto e reverso
            CreateMap<PessoaDTO, Pessoa>().ReverseMap().ReverseMap();
            CreateMap<PessoaDTOPost, Pessoa>().ReverseMap().ReverseMap();
            CreateMap<PessoaDTOPut, Pessoa>().ReverseMap().ReverseMap();
            
        }
    }
}