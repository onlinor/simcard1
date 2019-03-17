using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Supplier
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers(); 
        Task<Supplier> GetSupplier(int id, bool includeRelated = true);  
        Task<Supplier> AddSupplier(Supplier wh);
        void UpdateSupplier(Supplier wh);
        void Remove(Supplier Supplier);
        Task<bool> IsSupplierExists(string name);
          
    }
}