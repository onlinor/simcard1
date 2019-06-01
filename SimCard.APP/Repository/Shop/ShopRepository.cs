using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly SimCardDBContext _context;

        public ShopRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<ShopViewModel> AddShop(ShopViewModel shopViewModel)
        {
            if (shopViewModel != null)
            {
                var s = new Shop
                {
                    DateCreated = DateTime.Now,
                    Name = shopViewModel.Name,
                };
                await _context.AddAsync(s);
                await _context.SaveChangesAsync();
                return shopViewModel;
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
            return await _context.Shops.Where(s => s.Id != 1).ToListAsync();
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