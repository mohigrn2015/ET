using ET_DAL.IService;
using ET_DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Principal;
using ET_ENTITY.EntityModels;

namespace ET_DAL
{
    public static class DALServiceCollection 
    { 
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddTransient<IGenericService<ExpCategories>, RepoCategories>();
            services.AddTransient<IGenericService<DailyExpence>, RepoDailyExpence>();
            return services;
        }
    }
}
