using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PeticomDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PeticomConnectionString"));
        });
        services.AddScoped<ISomeFeatureEntityRepository, SomeFeatureEntityRepository>();

        return services;
    }
}