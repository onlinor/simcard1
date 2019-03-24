using AutoMapper;

using Microsoft.EntityFrameworkCore;
using SimCard.APP.Models;
using SimCard.APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class ExportReceiptRepository : IExportReceiptRepository
    {
        private readonly SimCardDBContext _context;

        public ExportReceiptRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<List<ExportReceiptViewModel>> GetAllAsync()
        {
            return Mapper.Map<List<ExportReceiptViewModel>>(await _context.ExportReceipts.ToListAsync());
        }

        public async Task<ExportReceiptViewModel> GetById(int id)
        {
            return Mapper.Map<ExportReceiptViewModel>(_context.ExportReceipts.FindAsync(id));
        }

        public IQueryable<ExportReceipt> Query(Expression<Func<ExportReceipt, bool>> predicate)
        {
            return _context.ExportReceipts.Where(predicate);
        }
    }
}
