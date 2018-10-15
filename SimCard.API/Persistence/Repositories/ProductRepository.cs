
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public SimCardDBContext Context { get; set; }
        public ProductRepository(SimCardDBContext context)
        {
            this.Context = context;
        }

        public async Task<Product> GetProduct(int ProductID)
        {
            return await Context.Products.FindAsync(ProductID);
        }

        public async Task<Product> AddProduct(Product product) 
        {   
            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();

            return product;
        }
    }
}