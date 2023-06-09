using Microsoft.AspNetCore.Identity;
using Peticom.Core.Entities;

namespace Peticom.WebAPI.Extensions;

public static class CorsExtension
{
    public static void UseCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("MyAllowedOrigins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // note the port is included 
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    policy.WithOrigins("https://peticom-frontend.vercel.app/")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            
                    policy.WithOrigins("https://peticom.com.tr")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            
                    policy.WithOrigins("https://www.peticom.com.tr")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}