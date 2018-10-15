using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int ProductID);
        Task<Product> AddProduct(Product product);
    }
}