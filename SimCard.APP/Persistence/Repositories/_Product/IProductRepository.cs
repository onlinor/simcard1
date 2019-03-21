using SimCard.APP.Models;
using SimCard.APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();

        Task<ProductViewModel> GetProduct(int id);

        IQueryable<Product> Query(Expression<Func<Product, bool>> predicate);

        Task<bool> AddProduct(ProductViewModel productViewModel);

        Task<bool> AddProducts(List<ProductViewModel> productViewModels);

        void UpdateProduct(ProductViewModel productViewModel);

        Task<bool> Remove(int id);

        Task<bool> IsProductExists(string code);
    }
}