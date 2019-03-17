using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._ImportReceipt
{
    public interface IImportReceiptsRepository
    {
        Task<string> GenerateID(); 
        Task<ImportReceipt> AddImportReceipt(ImportReceipt importReceipt);
    }
}