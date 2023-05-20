using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models;

namespace Peticom.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<PetIdentity, PetIdentityModel>().ReverseMap();
        CreateMap<Ad, AdModel>().ReverseMap();
    }
}