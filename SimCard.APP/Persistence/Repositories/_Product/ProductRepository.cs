using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SimCardDBContext _context;

        public ProductRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProducts(Product pr)
        {
            if (await IsProductExists(pr))
            {
                Product product = await _context.Products.FirstAsync(x => x.Name.ToLower() == pr.Name.ToLower());
                // ProductToAdd.Quantity = ProductToAdd.Quantity + pr.Quantity;

                _context.Products.Update(product);
                return product;
            }

            await _context.Products.AddAsync(pr);

            return pr;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> IsProductExists(Product pr)
        {
            if (await _context.Products.AnyAsync(x => x.Name.ToLower() == pr.Name.ToLower()))
            {
                return true;
            }

            return false;
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void UpdateProduct(Product pr)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Product> Query(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }
    }
}