using Microsoft.EntityFrameworkCore;
using Registration.Data.Context;
using Registration.Data.Contracts;
using Registration.Data.Repositories.Core;
using Registration.Model;
using Registration.Model.Provider;

namespace Registration.Data.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(PostgreSqlContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Provider>> GetProviders()
        {
            return await Context.Provider
                .Include(x => x.Address)
                .ToListAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await Context.Provider
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddProviderAsync(Provider provider)
        {
            await Context.AddAsync(provider);
            await Context.SaveChangesAsync();
        }
    }
}
