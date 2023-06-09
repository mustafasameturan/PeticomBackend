using Microsoft.AspNetCore.Identity;
using Peticom.Core.Entities;
using Peticom.Repository;
using Peticom.Service.Constants;

namespace Peticom.WebAPI.Extensions;

public static class IdentityExtension
{
    public static void AddIdentity(this IServiceCollection services)
    {
        //Identity Configurations
        services.AddIdentity<UserApp, IdentityRole>(Opt =>
        {
            Opt.User.RequireUniqueEmail = true;

            Opt.Password.RequiredLength = 6;
            Opt.Password.RequireLowercase = true;
            Opt.Password.RequireUppercase = false;
            Opt.Password.RequireNonAlphanumeric = false;
            Opt.Password.RequireDigit = false;

        })
            .AddErrorDescriber<ErrorDescriber>()
            .AddEntityFrameworkStores<PeticomDbContext>()
            .AddDefaultTokenProviders();
    }
}