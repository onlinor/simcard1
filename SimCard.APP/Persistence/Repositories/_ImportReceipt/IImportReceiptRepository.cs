using SimCard.APP.Models;

using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IImportReceiptRepository
    {
        Task<string> GenerateID();
        Task<ImportReceipt> AddImportReceipt(ImportReceipt importReceipt);
    }
}