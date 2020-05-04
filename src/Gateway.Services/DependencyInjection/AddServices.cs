using Gateway.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Services.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStorageService, StorageService>();

            return services;
        }
    }
}
