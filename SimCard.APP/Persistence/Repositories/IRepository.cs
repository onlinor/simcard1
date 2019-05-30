using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        IQueryable<T> Query(Expression<Func<T, bool>> predicate);

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Remove(T entity);

        Task<bool> Remove(int id);
    }
}
