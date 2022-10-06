using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Model.Account;
using Registration.Model.Provider;

namespace Registration.Data.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) 
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Provider> Provider { get; set; }
    }
}
