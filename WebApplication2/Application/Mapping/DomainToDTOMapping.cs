using AutoMapper;
using Car.Domain.DTOs.Car;
using Car.Domain.DTOs.Person;
using Car.Domain.Model.PersonAggregate;
using Car.Domain.Model.CarAggregate;
using Cars.Domain.DTOs.Car;
using APICars.Domain.DTOs.Car;

namespace Car.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<PersonDTO, Person>();
                
            CreateMap<Person, PersonDTO>();

            CreateMap<PersonCreateDTO, Person>()
                .ForMember(dest => dest.created_on, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));

            CreateMap<PersonUpdateDTO, Person>();

            CreateMap<CarCreateDTO, Vehicle>()
                .ForMember(dest => dest.created_on, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));

            CreateMap<Vehicle, CarDTO>();

            CreateMap<CarDTO, Vehicle>();

            CreateMap<CarUpdateDTO, Vehicle>();
        }
    }
}
