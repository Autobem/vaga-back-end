using AutoMapper;
using DevAssuncaoCarros.API.ViewModels;
using DevAssuncaoCarros.Business.Models;

namespace DevAssuncaoCarros.API.Configurations
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<ProprietarioViewModel, Proprietario>().ReverseMap();
        }
    }
}
