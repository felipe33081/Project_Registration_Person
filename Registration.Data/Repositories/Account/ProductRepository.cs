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

        public async Task<ListDataPagination<Product>> ListPersonAsync(
            string? searchString,
            int page,
            int size,
            DateTimeOffset? initialDate,
            DateTimeOffset? finalDate,
            string? orderBy)
        {
            var query = Context.Product
                .Where(q => !q.IsDeleted);

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower().Trim();
                query = query.Where(q => q.Price.Contains(searchString) ||
                                         q.Description.ToLower().Contains(searchString));
            }

            if (initialDate.HasValue)
            {
                query = query.Where(q => q.CreatedAt >= initialDate);
            }

            if (finalDate.HasValue)
            {
                query = query.Where(q => q.CreatedAt <= finalDate);
            }

            switch (orderBy)
            {
                case "createdAt_DESC":
                    query = query.OrderByDescending(t => t.CreatedAt);
                    break;
                case "createdAt_ASC":
                    query = query.OrderBy(t => t.CreatedAt);
                    break;
                default:
                    query = query.OrderByDescending(t => t.CreatedAt);
                    break;
            }

            var data = new ListDataPagination<Product>
            {
                Page = page,
                TotalItems = await query.CountAsync()
            };
            data.TotalPages = (int)Math.Ceiling((double)data.TotalItems / size);

            data.Data = await query.Skip(size * page)
                   .Take(size)
                   .AsNoTracking()
                   .ToListAsync();

            return data;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Context.Product
                .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task AddProductAsync(Product product)
        {
            await Context.AddAsync(product);
            await Context.SaveChangesAsync();
        }
    }
}
