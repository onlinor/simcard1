using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IImportReceiptRepository
    {
        Task<string> GenerateProductCode();

        Task<ImportReceipt> AddImportReceipt(ImportReceiptViewModel importReceipt);
    }
}