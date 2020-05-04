using Microsoft.Extensions.DependencyInjection;

namespace Gateway.DataAccess.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddTransient<IStorageRepository, StorageRepository>();

            return services;
        }
    }
}
