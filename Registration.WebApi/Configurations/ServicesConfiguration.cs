using Registration.Data.Contracts;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories;
using Registration.Data.Repositories.Account;

namespace Registration.WebApi.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProviderRepository, ProviderRepository>();

            return services;
        }
    }
}