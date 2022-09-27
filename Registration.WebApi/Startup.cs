using AutoMapper;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Account;

namespace Registration.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
               .AddAuthorization()
               .AddDataAnnotations();

            services.AddMemoryCache();
            services.AddCors();
            services.AddDistributedMemoryCache();

            services.AddScoped<MapperProfile>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        { 

        }
    }
}
