using SimCard.APP.Models;
using SimCard.APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IShopRepository
    {
        Task<ShopViewModel> AddShop(ShopViewModel ShopViewModel);
        Task<IEnumerable<Shop>> GetShops();

        IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate);

        Task<Shop> GetShop(int id, bool includeRelated = true);

        void Remove(Shop shop);
    }
}