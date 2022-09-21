using Microsoft.EntityFrameworkCore;
using Registration.Data.Context;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Core;
using Registration.Model;
using Registration.Model.Account;

namespace Registration.Data.Repositories.Account
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(PostgreSqlContext context) : base(context)
        {

        }

        public async Task<ListDataPagination<Person>> ListPersonAsync(
            string searchString,
            int page,
            int size,
            DateTimeOffset? initialDate,
            DateTimeOffset? finalDate,
            string orderBy)
        {
            var query = Context.Person
                .Where(q => !q.IsDeleted);

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower().Trim();
                query = query.Where(q => q.RegistrationNumber.Contains(searchString) ||
                                         q.Name.ToLower().Contains(searchString));
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

            var data = new ListDataPagination<Person>
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

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            return await Context.Person
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task AddPersonAsync(Person person)
        {
            await Context.AddAsync(person);
        }
    }
}
