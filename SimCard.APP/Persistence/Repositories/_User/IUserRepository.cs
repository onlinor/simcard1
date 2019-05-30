using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<bool> Create(User user);

        IQueryable<User> Query(Expression<Func<User, bool>> predicate);

    }
}
