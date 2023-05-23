using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Models.PetVaccine;

namespace Peticom.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<PetIdentity, PetIdentityModel>().ReverseMap();
        CreateMap<Ad, AdModel>().ReverseMap();
        CreateMap<PetDisease, PetDiseaseModel>().ReverseMap();
        CreateMap<PetIdentity, PetFullIdentityModel>().ReverseMap();
        CreateMap<PetVaccine, PetVaccineModel>().ReverseMap();
    }
}