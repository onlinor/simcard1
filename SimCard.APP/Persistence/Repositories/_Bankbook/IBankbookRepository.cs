using SimCard.APP.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IBankbookRepository
    {
        Task<IEnumerable<Bankbook>> GetAllBankbook();

        Task<Bankbook> GetBankbook(int id);

        Task<Bankbook> AddBankbook(Bankbook bankbookParams);

        Task<Bankbook> UpdateBankbook(int id, Bankbook bankbookParams);

        //Task<int> GetLastIDBankbookRecord();

        void Remove(Bankbook bankbookParams);
    }
}