using AutoMapper;
using Cars.Domain.DTOs;
using Cars.Domain.Model.PersonAggregate;

namespace Cars.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<PersonDTO, Person>()
                .ForMember(dest => dest.created_on, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));
        }
    }
}
