using DataStorage.DataAccess.EntityFramework;
using DataStorage.DataAccess.EntityFramework.Interfaces;
using DataStorage.DataAccess.Repositories;
using DataStorage.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataStorage.DataAccess.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<ICarRepository, CarRepository>();

            services.AddScoped<IDataStorageDbContextDbContextFactory, DataStorageDbContextDbContextFactory>();

            return services;
        }
    }
}
