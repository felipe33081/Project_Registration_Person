using Registration.Data.Contracts.Core;
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
        //Task<ListDataPagination<Person>> ListPerson(User User, string searchString, int page, int size, DateTimeOffset? initialDate, DateTimeOffset? finalDate, string orderBy, bool isDeleted);

        //Task<Person> GetPersonAsync(User User, Guid PersonId);

        Task AddUserPersonAsync(Person person);

        //void RemoveUserPerson(UserPerson userPerson);
    }
}
