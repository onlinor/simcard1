using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Product
{    
    public class ProductRepository : IProductRepository
    {
        private readonly SimCardDBContext context;       

        public ProductRepository(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task<Product> AddProducts(Product pr)
        {
            if(await IsProductExists(pr))
            {
                var ProductToAdd = await context.Products.FirstAsync(x => x.Name.ToLower() == pr.Name.ToLower());
                ProductToAdd.Quantity = ProductToAdd.Quantity + pr.Quantity;
                
                context.Products.Update(ProductToAdd);
                return ProductToAdd;
            }

            await context.Products.AddAsync(pr);

            return pr;           
        }

        public async Task<Product> GetProduct(int id, bool includeRelated = true)
        {
            // if (!includeRelated)
            //     return await context.Products.FindAsync(id);

            return await context.Products            
                .FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<bool> IsProductExists(Product pr)
        {
            if (await context.Products.AnyAsync(x => x.Name.ToLower() == pr.Name.ToLower()))
                return true;
            return false;
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

        public void UpdateProduct(Product pr)
        {
            throw new System.NotImplementedException();
        }
    }
}