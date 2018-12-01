using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Warehouse
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly SimCardDBContext context;
        public WarehouseRepository(SimCardDBContext context)
        {
            this.context = context;

        }

        public async Task<Warehouse> Addwarehouse(Warehouse wh)
        {
            await context.Warehouses.AddAsync(wh);

            return wh;
        }

        public async Task<Warehouse> GetWarehouse(int id, bool includeRelated = true)
        {
            return await context.Warehouses.FindAsync(id);

            // return await context.Warehouses            
            //     .Include(v => v.Products)                
            //     .SingleOrDefaultAsync(v => v.Id == id);
        }
        
        public async Task<IEnumerable<Warehouse>> GetWarehouses()
        {
            return await context.Warehouses.ToListAsync();
        }

        public async Task<bool> IsWarehouseExists(string name)
        {
            if (await context.Warehouses.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

        public void Remove(Warehouse warehouse)
        {
            context.Warehouses.Remove(warehouse);
        }

        public void Updatewarehouse(Warehouse wh)
        {
            context.Warehouses.Update(wh);
        }
    }
}