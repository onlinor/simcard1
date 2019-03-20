using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SimCardDBContext context;
        public SupplierRepository(SimCardDBContext context)
        {
            this.context = context;

        }

        public async Task<Supplier> AddSupplier(Supplier Sp)
        {
            await context.Suppliers.AddAsync(Sp);
            return Sp;
        }

        public async Task<Supplier> GetSupplier(int id, bool includeRelated = true)
        {
            return await context.Suppliers.FindAsync(id);
        }
        
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await context.Suppliers.ToListAsync();
        }

        public async Task<bool> IsSupplierExists(string name)
        {
            if (await context.Suppliers.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

        public void Remove(Supplier Supplier)
        {
            context.Suppliers.Remove(Supplier);
        }

        public void UpdateSupplier(Supplier Sp)
        {
            context.Suppliers.Update(Sp);
        }
    }
}