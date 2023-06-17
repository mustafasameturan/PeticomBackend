using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.City;
using Peticom.Core.Models.Comment;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Models.PeticomerApplication;
using Peticom.Core.Models.PeticomerBadge;
using Peticom.Core.Models.PeticomerHome;
using Peticom.Core.Models.PetVaccine;
using Peticom.Core.Models.Reservation;
using Peticom.Core.Models.Star;
using Peticom.Core.Models.SubComment;
using Peticom.Core.Models.User;

namespace Peticom.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<PetIdentity, PetIdentityModel>().ReverseMap();
        CreateMap<PetIdentity, PetFullIdentityModel>().ReverseMap();
        CreateMap<PetIdentity, PetIdentitySelectListModel>().ReverseMap();
        
        CreateMap<Ad, AdModel>().ReverseMap();
        
        CreateMap<PetDisease, PetDiseaseModel>().ReverseMap();
        
        CreateMap<PetVaccine, PetVaccineModel>().ReverseMap();
        
        CreateMap<Comment, CommentModel>().ReverseMap();
        
        CreateMap<SubComment, SubCommentModel>().ReverseMap();
        
        CreateMap<PeticomerBadge, PeticomerBadgeModel>().ReverseMap();
        
        CreateMap<PeticomerHome, PeticomerHomeModel>().ReverseMap();
        
        CreateMap<Star, StarModel>().ReverseMap();
        
        CreateMap<PeticomerApplication, PeticomerApplicationModel>().ReverseMap();
        CreateMap<PeticomerApplication, PeticomerApplicationWithStatusModel>().ReverseMap();

        CreateMap<UserApp, UserAppModel>()
            .ReverseMap();
            //.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate ?? DateTime.MinValue));
        
        CreateMap<City, CityModel>().ReverseMap();
        
        CreateMap<Reservation, ReservationModel>().ReverseMap();
    }
}