using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Warehouse
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetWarehouses(); 
        Task<Warehouse> GetWarehouse(int id, bool includeRelated = true);  
        Task<Warehouse> Addwarehouse(Warehouse wh);
        void Updatewarehouse(Warehouse wh);
        void Remove(Warehouse warehouse);
        Task<bool> IsWarehouseExists(string name);
          
    }
}