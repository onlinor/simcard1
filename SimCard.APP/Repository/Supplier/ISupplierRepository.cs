using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Repository
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