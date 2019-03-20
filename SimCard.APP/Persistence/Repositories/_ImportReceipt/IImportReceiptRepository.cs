using SimCard.API.Models;

using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface IImportReceiptsRepository
    {
        Task<string> GenerateID();
        Task<ImportReceipt> AddImportReceipt(ImportReceipt importReceipt);
    }
}