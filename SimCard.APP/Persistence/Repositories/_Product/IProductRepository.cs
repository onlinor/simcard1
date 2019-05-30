using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();

        Task<ProductViewModel> GetProduct(int id);

        // Task<List<ExpandoObject>> GetAllProductsGroupByType();

        IQueryable<Product> Query(Expression<Func<Product, bool>> predicate);

        Task<bool> AddProducts(List<ProductViewModel> productViewModels);

        Task<bool> UpdateProduct(ProductViewModel productViewModel);

        Task<bool> Remove(int id);

        Task<bool> IsProductExists(string code);
    }
}