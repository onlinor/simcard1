using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IImportReceiptRepository
    {
        Task<string> GenerateProductCode();

        Task<ImportReceipt> AddImportReceipt(ImportReceiptViewModel importReceipt);

        Task<List<ImportReceiptViewModel>> GetAllAsync();

        Task<ImportReceiptViewModel> GetByIdAsync(int id);

        IQueryable<ImportReceipt> Query(Expression<Func<ImportReceipt, bool>> predicate);

    }
}