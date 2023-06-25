using AutoMapper;
using Domain.Models;
using Domain.Models.UserModels;
using Entities.Entities;

namespace Infrastructure.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Owner, OwnerModel>().ReverseMap();
        CreateMap<Vehicle, VehicleModel>().ReverseMap();
        CreateMap<User, CreateUserModel>().ReverseMap();
        CreateMap<User, GetUserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();
    }
}