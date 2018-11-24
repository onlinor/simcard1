using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id, bool includeRelated = true);    
        Task<Product> AddProducts(Product pr);
        void UpdateProduct(Product pr);     
        void Remove(Product product);  
        Task<bool> IsProductExists(Product pr);     
    }
}