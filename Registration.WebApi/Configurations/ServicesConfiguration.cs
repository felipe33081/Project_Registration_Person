using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Account;

namespace Registration.WebApi.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}