using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Business.Services;

public class AdService : GenericService<Ad, AdModel>, IAdService
{
    public AdService(IUnitOfWork unitOfWork, IGenericRepository<Ad> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }
}