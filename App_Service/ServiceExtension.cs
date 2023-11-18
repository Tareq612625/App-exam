using App_Model;
using App_Service.AuthorizationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GimsDbcontext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SessionRepo>(); // Register session class

            return services;
        }
        //public static IServiceCollection AddSessionAuthServices(this IServiceCollection services)
        //{
        //    services.AddAuthorizationCore(options =>
        //    {
        //        options.AddPolicy("SessionNotNull", policy =>
        //        {
        //            policy.Requirements.Add(new SessionNotNullRequirement());
        //        });
        //    });

        //    services.AddScoped<SessionNotNullHandler>();

        //    return services;
        //}
    }
}