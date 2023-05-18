using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Business.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<PetIdentity, PetIdentityModel>().ReverseMap();
        CreateMap<Ad, AdModel>().ReverseMap();
    }
}