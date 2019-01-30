using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public interface ICashbookRepository
    {
        Task<IEnumerable<Cashbook>> GetAllCashbook();
        Task<Cashbook> GetCashbook(int id);

        Task<Cashbook> AddCashbook(Cashbook cashbookParams);

        Task<Cashbook> UpdateCashbook(int id, Cashbook cashbookParams);

        Task<int> GetLastIDCashbookRecord();

        void Remove(Cashbook cashbookParams);
    }
}