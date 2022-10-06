using Registration.Data.Contracts.Core;
using Registration.Model;
using Registration.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Data.Contracts.Account
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<ListDataPagination<Product>> ListPersonAsync( string? searchString, int page, int size, DateTimeOffset? initialDate, DateTimeOffset? finalDate, string? orderBy);

        Task<Product> GetProductByIdAsync(int id);

        Task AddProductAsync(Product product);
    }
}
