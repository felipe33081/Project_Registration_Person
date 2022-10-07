using Microsoft.EntityFrameworkCore;
using Registration.Data.Context;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Core;
using Registration.Model;
using Registration.Model.Account;

namespace Registration.Data.Repositories.Account
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PostgreSqlContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Context.Product.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Context.Product
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddProductAsync(Product product)
        {
            await Context.AddAsync(product);
            await Context.SaveChangesAsync();
        }
    }
}
