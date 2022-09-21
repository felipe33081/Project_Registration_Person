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
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<ListDataPagination<Person>> ListPersonAsync( string searchString, int page, int size, DateTimeOffset? initialDate, DateTimeOffset? finalDate, string orderBy);

        Task<Person> GetPersonByIdAsync(Guid id);

        Task AddPersonAsync(Person person);
    }
}
