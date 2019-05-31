using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;


namespace SimCard.APP.Repository
{
    public interface IDebtbookRepository
    {
        Task<IEnumerable<Debtbook>> GetAllDebtbook();

        Task<Debtbook> AddDebtbook(Debtbook debtbookParams);

    }
}