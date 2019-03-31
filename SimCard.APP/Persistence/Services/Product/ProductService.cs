using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return await _repository.Create(product);
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            return Mapper.Map<ProductViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return Mapper.Map<List<ProductViewModel>>(await _repository.GetAll());
        }

        public async Task<bool> IsExisted(string code, int shopId)
        {
            Product product = await _repository.Query(x => x.Ma.ToLower() == code.ToLower() && x.ShopId.Value == shopId).FirstOrDefaultAsync();
            return product != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return await _repository.Update(product);
        }
    }
}
