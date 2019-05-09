using Microsoft.EntityFrameworkCore;
using SimCard.APP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class DebtbookRepository : IDebtbookRepository
    {
        private readonly SimCardDBContext _context;

        public DebtbookRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Debtbook>> getAllDebtbook()
        {
            return await _context.Debtbook.ToListAsync();
        }
        
        public async Task<Debtbook> addDebtbook(Debtbook debtbook)
        {
            if (debtbook != null)
            {
                await _context.AddAsync(debtbook);
                await _context.SaveChangesAsync();
                return debtbook;
            }
            return null;
        }
    }
}
