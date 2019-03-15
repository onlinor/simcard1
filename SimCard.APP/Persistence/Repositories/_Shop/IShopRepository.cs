using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Shop
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetShops();
        IQueryable<Shop> Query(Expression<Func<Shop, bool>> predicate);
        Task<Shop> GetShop(int id, bool includeRelated = true);         
        void Remove(Shop shop);       
    }
}