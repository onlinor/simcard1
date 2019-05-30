using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
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

        public async Task<Supplier> GetSupplier(int id)
        {
            return await context.Suppliers.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await context.Suppliers.Include(s => s.Products).ToListAsync();
        }

        public async Task<bool> IsSupplierExists(string name)
        {
            if (await context.Suppliers.AnyAsync(x => x.Name == name))
            {
                return true;
            }

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

        public IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate)
        {
            return context.Shops.Where(predicate);
        }
    }
}