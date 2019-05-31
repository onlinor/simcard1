using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SimCardDBContext _context;

        public SupplierRepository(SimCardDBContext context)
        {
            _context = context;

        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            return supplier;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await _context.Suppliers.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers.Include(s => s.Products).ToListAsync();
        }

        public async Task<bool> IsSupplierExists(string name)
        {
            if (await _context.Suppliers.AnyAsync(x => x.Name == name))
            {
                return true;
            }

            return false;
        }

        public void Remove(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
        }

        public IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate)
        {
            return _context.Shops.Where(predicate);
        }
    }
}