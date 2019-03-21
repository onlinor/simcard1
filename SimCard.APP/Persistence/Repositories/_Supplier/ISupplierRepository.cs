using SimCard.APP.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplier(int id);

        Task<Supplier> AddSupplier(Supplier wh);

        void UpdateSupplier(Supplier wh);

        void Remove(Supplier Supplier);

        Task<bool> IsSupplierExists(string name);

    }
}