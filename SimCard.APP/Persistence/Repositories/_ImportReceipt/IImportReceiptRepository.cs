using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IImportReceiptRepository
    {
        Task<string> GenerateID();

        Task<ImportReceipt> AddImportReceipt(ImportReceiptViewModel importReceipt);

        Task<List<ImportReceiptViewModel>> GetAllAsync();

        Task<ImportReceiptViewModel> GetByIdAsync(int id);

        IQueryable<ImportReceipt> Query(Expression<Func<ImportReceipt, bool>> predicate);

    }
}