using Api.Domain.DTO.Pessoa;
using Api.Domain.Models;
using AutoMapper;

namespace Api.InfraCrossCutting.Mappings
{
    public class DTOParaModelProfile : Profile
    {
        public DTOParaModelProfile()
        {
            //mapeamento models para dto e reverso
            CreateMap<PessoaModel, PessoaDTO>().ReverseMap();
            CreateMap<PessoaModel, PessoaDTOPutRequest>().ReverseMap();
        }
    }
}