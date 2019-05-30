using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Repository
{
    public interface IExportReceiptRepository
    {
        Task<string> GenerateProductCode();

        Task<ExportReceipt> AddExportReceipt(ExportReceiptViewModel exportReceipt);

        Task<List<ExportReceiptViewModel>> GetAllAsync();

        Task<ExportReceiptViewModel> GetById(int id);

        IQueryable<ExportReceipt> Query(Expression<Func<ExportReceipt, bool>> predicate);

    }
}
