using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class DebtbookRepository : IDebtbookRepository
    {
        private readonly SimCardDBContext _context;

        public DebtbookRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Debtbook>> GetAllDebtbook()
        {
            return await _context.Debtbook.ToListAsync();
        }

        public async Task<Debtbook> AddDebtbook(Debtbook debtbook)
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
