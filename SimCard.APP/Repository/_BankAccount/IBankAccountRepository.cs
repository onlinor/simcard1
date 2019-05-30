using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Repository
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccountViewModel>> GetAll();

        Task<BankAccountViewModel> GetByIdAsync(int id);

        Task<bool> Create(BankAccount bankAccount);

        Task<bool> Update(BankAccount bankAccount);

        Task<bool> Delete(BankAccount bankAccount);

        Task<bool> Delete(int id);
    }
}
