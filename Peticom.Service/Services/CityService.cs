using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models.City;
using Peticom.Core.Repositories;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class CityService : GenericService<City, CityModel>, ICityService
{
    public CityService(IUnitOfWork unitOfWork, IGenericRepository<City> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }
}