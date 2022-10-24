using ET_BLL.BLLRepository;
using ET_BLL.IBllService;
using ET_DAL.Repository;
using ET_ENTITY.EntityModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ET_BLL
{ 
    public static class BLLServiceCollection
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddTransient<IBLLGenericService<ExpCategories>, BLLRepoCategories>();
            services.AddTransient<IBLLGenericService<DailyExpence>, BLLRepoDailyExpensive>();
            return services;
        }
    }
}
