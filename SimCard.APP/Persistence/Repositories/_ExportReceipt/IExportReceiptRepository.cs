using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IExportReceiptRepository
    {
        Task<string> GenerateProductCode();
        Task<List<ExportReceiptViewModel>> GetAllAsync();

        Task<ExportReceiptViewModel> GetById(int id);

        IQueryable<ExportReceipt> Query(Expression<Func<ExportReceipt, bool>> predicate);

    }
}
