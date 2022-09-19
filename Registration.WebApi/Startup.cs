using Registration.Data.Context;

namespace Registration.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        private static PostgreSqlContext GetPostgreSql(IServiceCollection services)
        {
            return (PostgreSqlContext)services.BuildServiceProvider().GetService(typeof(PostgreSqlContext));
        }

        private static ILogger<Startup> GetLogger(IServiceCollection services)
        {
            return (ILogger<Startup>)services.BuildServiceProvider().GetService(typeof(ILogger<Startup>));
        }
    }
}
