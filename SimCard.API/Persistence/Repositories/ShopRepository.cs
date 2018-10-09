using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{    
    public class ShopRepository : IShopRepository
    {
        private readonly SimCardDBContext context;    

        public ShopRepository(SimCardDBContext context)
        {
            this.context = context;
        }        

        public async Task<Shop> GetShop(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Shops.FindAsync(id);

            return await context.Shops            
                .Include(v => v.Products)                
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Shop>> GetShops()
        {
            return await context.Shops.Include(m => m.Products).ToListAsync();
        }

        public void Remove(Shop shop)
        {
            context.Remove(shop);
        }
    }
}