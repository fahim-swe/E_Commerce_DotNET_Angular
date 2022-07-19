using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helper;
using API.Interface;
using API.Service;
using E_Commerce_App_Practices_1.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration _config)
        {
            string mySqlConnectionStr = _config.GetConnectionString("DefaultConnection");  
            services.AddDbContext<StoreContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))); 
            
            return services;
        }

        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IEntityBaseRepository<>), (typeof(EntityBaseRepository<>)));

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
}