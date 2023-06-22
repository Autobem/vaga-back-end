using AutoMapper;
using Domain.Models;
using Entities.Entities;

namespace Infrastructure.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Owner, OwnerModel>().ReverseMap();
        CreateMap<Vehicle, VehicleModel>().ReverseMap();
    }
}