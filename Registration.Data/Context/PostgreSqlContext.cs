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
    }
}
