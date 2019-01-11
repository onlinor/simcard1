using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Shop
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetShops();
        Task<Shop> GetShop(int id, bool includeRelated = true);         
        void Remove(Shop shop);       
    }
}