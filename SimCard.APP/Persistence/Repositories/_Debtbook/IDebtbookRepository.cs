using SimCard.APP.Models;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace SimCard.APP.Persistence.Repositories
{
    public interface IDebtbookRepository
    {
        Task<IEnumerable<Debtbook>> getAllDebtbook();

        Task<Debtbook> addDebtbook(Debtbook debtbookParams);

    }
}