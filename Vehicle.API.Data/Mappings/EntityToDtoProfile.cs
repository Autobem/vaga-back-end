using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Owner;
using Vehicles.API.Domain.Dtos.User;
using Vehicles.API.Domain.Dtos.Vehicle;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Data.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //CreateMap<Vehicle, OwnerDto>().ReverseMap().ForMember(d => d.Owner, opts => opts.MapFrom(src => src.OwnerId));
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDtoCreate>().ReverseMap();
            CreateMap<Vehicle, VehicleDtoUpdate>().ReverseMap();

            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Owner, OwnerDtoCreate>().ReverseMap();
            CreateMap<Owner, OwnerDtoUpdate>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDtoCreate>().ReverseMap();
        }
    }
}
