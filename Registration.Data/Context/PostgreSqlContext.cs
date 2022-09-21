using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Model.Account;

namespace Registration.Data.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) 
        {

        }

        public DbSet<Person> Person { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    var builder = new ConfigurationBuilder();
        //    //builder.SetBasePath(Directory.GetCurrentDirectory());
        //    //builder.AddJsonFile("appsettings.json");
        //    IConfiguration Configuration = builder.Build();

        //    optionsBuilder.UseNpgsql(
        //        Configuration.GetConnectionString("POSTGRESQLCONNSTR_PostgreSQL"));
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
