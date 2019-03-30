using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly SimCardDBContext _context;

        public ShopRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<ShopViewModel> AddShop(ShopViewModel shop)
        {
            if (shop != null)
            {
                Shop s = new Shop
                {
                    DateCreated = DateTime.Now,
                    Id = shop.Id,
                    Name = shop.Name
                };
                await _context.AddAsync(s);
                await _context.SaveChangesAsync();
                return shop;
            }
            return null;
        }
        public async Task<Shop> GetShop(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await _context.Shops.FindAsync(id);
            }

            return await _context.Shops
                .Include(s => s.Childrens).Include(s => s.Products)       //temp          
                .SingleOrDefaultAsync(v => v.Id == 78);
        }

        public async Task<IEnumerable<Shop>> GetShops()
        {
            return await _context.Shops.Include(s => s.Childrens).Include(s => s.Products).ToListAsync();  //temp  
        }

        public void Remove(Shop shop)
        {
            _context.Shops.Remove(shop);
        }
        public IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate)
        {
            return _context.Shops.Where(predicate);
        }
    }
}