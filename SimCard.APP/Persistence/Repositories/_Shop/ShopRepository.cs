using Microsoft.EntityFrameworkCore;

using SimCard.API.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            {
                return await context.Shops.FindAsync(id);
            }

            return await context.Shops
                .Include(v => v.Id)       //temp          
                .SingleOrDefaultAsync(v => v.Id == "78");
        }

        public async Task<IEnumerable<Shop>> GetShops()
        {
            return await context.Shops.Include(m => m.Id).ToListAsync();  //temp  
        }

        public IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate)
        {
            return context.Shops.Where(predicate);
        }

        public void Remove(Shop shop)
        {
            context.Shops.Remove(shop);
        }
    }
}