using DataStorage.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataStorage.Services.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();

            services.AddTransient<ICarService, CarService>();

            return services;
        }
    }
}
