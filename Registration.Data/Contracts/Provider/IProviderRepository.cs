using Registration.Data.Contracts.Core;
using Registration.Model;
using Registration.Model.Provider;

namespace Registration.Data.Contracts
{
    public interface IProviderRepository : IRepositoryBase<Provider>
    {
        Task<IEnumerable<Provider>> GetProviders();
        Task<Provider> GetProviderByIdAsync(int id);
        Task AddProviderAsync(Provider provider);
    }
}
