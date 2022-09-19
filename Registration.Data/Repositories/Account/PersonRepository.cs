using Registration.Data.Context;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Core;
using Registration.Model.Account;

namespace Registration.Data.Repositories.Account
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(PostgreSqlContext context) : base(context)
        {

        }

        //public async Task<ListDataPagination<Person>> ListPerson(
        //    User user,
        //    string searchString,
        //    int page,
        //    int size,
        //    DateTimeOffset? initialDate,
        //    DateTimeOffset? finalDate,
        //    string orderBy,
        //    bool isDeleted)
        //{
        //    var permLevel = await _permissionRepository.GetPermissionLevelAsync(user, PermissionResource.Person, PermissionType.Read);
        //    var query = Context.Person
        //        .Include(x => x.Tenant)
        //        .Where(WithTenantFilter<Person>(user))
        //        .Where(WithPermissionFilter<Person>(user, permLevel, _generalSettings.EnableLegacyPermission));

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        searchString = searchString.ToLower().Trim();
        //        query = query.Where(q => q.RegistrationNumber.Contains(searchString) ||
        //                                 q.Name.ToLower().Contains(searchString));
        //    }

        //    if (isDeleted == true)
        //    {
        //        query = query.Where(q => q.isDeleted == true);
        //    }
        //    else
        //    {
        //        query = query.Where(q => q.isDeleted == false);
        //    }

        //    if (initialDate.HasValue)
        //    {
        //        query = query.Where(q => q.CreatedAt >= initialDate);
        //    }

        //    if (finalDate.HasValue)
        //    {
        //        query = query.Where(q => q.CreatedAt <= finalDate);
        //    }

        //    switch (orderBy)
        //    {
        //        case "createdAt_DESC":
        //            query = query.OrderByDescending(t => t.CreatedAt);
        //            break;
        //        case "createdAt_ASC":
        //            query = query.OrderBy(t => t.CreatedAt);
        //            break;
        //        default:
        //            query = query.OrderByDescending(t => t.CreatedAt);
        //            break;
        //    }

        //    var data = new ListDataPagination<Person>
        //    {
        //        Page = page,
        //        TotalItems = await query.CountAsync()
        //    };
        //    data.TotalPages = (int)Math.Ceiling((double)data.TotalItems / size);

        //    data.Data = await query.Skip(size * page)
        //           .Take(size)
        //           .AsNoTracking()
        //           .ToListAsync();

        //    return data;
        //}

        //public async Task<Person> GetPersonAsync(User user, Guid PersonId)
        //{
        //    var permLevel = await _permissionRepository.GetPermissionLevelAsync(user, PermissionResource.Person, PermissionType.Read);
        //    return await Context.Person
        //        .Include(x => x.UserPerson)
        //        .Include(x => x.BankAccounts)
        //        .Include(x => x.Address)
        //        .Include(x => x.Tenant)
        //        .Include(x => x.Uploads)
        //        .Include(x => x.EconomicActivityCode)
        //        .Where(WithTenantFilter<Person>(user))
        //        .Where(WithPermissionFilter<Person>(user, permLevel, _generalSettings.EnableLegacyPermission))
        //        .SingleOrDefaultAsync(x => x.Id == PersonId && !x.isDeleted);
        //}

        public async Task AddUserPersonAsync(Person person)
        {
            await Context.AddAsync(person);
        }

        //public void RemoveUserPerson(UserPerson userPerson)
        //{
        //    Context.Remove(userPerson);
        //}
    }
}
