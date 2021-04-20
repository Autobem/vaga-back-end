using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.InfraCrossCutting.Mappings
{
    public class ModelParaEntityProfile : Profile
    {
        public ModelParaEntityProfile()
        {
            CreateMap<Pessoa, PessoaModel>().ReverseMap().ReverseMap();
        }
    }
}