using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly SimCardDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountRepository(SimCardDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(BankAccount bankAccount)
        {
            await _context.BankAccounts.AddAsync(bankAccount);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> Delete(BankAccount bankAccount)
        {
            _context.BankAccounts.Remove(bankAccount);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> Delete(int id)
        {
            BankAccount bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _context.BankAccounts.Remove(bankAccount);
                return await _unitOfWork.SaveChangeAsync();
            }
            return false;
        }

        public async Task<IEnumerable<BankAccountViewModel>> GetAll()
        {
            return Mapper.Map<List<BankAccountViewModel>>(await _context.BankAccounts.ToListAsync());
        }

        public async Task<BankAccountViewModel> GetByIdAsync(int id)
        {
            return Mapper.Map<BankAccountViewModel>(await _context.BankAccounts.FindAsync(id));
        }

        public async Task<bool> Update(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);
            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
