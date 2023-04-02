using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class SomeFeatureEntityRepository : Repository<SomeFeatureEntity, PeticomDatabaseContext>, ISomeFeatureEntityRepository
{
    public SomeFeatureEntityRepository(PeticomDatabaseContext context) : base(context)
    {
    }
}  
    
