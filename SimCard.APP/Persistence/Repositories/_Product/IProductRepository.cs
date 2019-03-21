using SimCard.APP.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        IQueryable<Product> Query(Expression<Func<Product, bool>> predicate);

        Task<Product> AddProducts(Product pr);

        void UpdateProduct(Product pr);

        void Remove(Product product);

        Task<bool> IsProductExists(Product pr);
    }
}