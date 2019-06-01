using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public interface ICashbookRepository
    {
        Task<IEnumerable<Cashbook>> GetAllCashbook();
        Task<Cashbook> GetCashbook(int id);

        Task<Cashbook> AddCashbook(Cashbook cashbookParams);

        Task<Cashbook> UpdateCashbook(int id, Cashbook cashbookParams);

        // Task<int> GetLastIDCashbookRecord();

        void Remove(Cashbook cashbookParams);

        IQueryable<Cashbook> Query(Expression<Func<Cashbook, bool>> predicate);
    }
}