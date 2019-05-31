using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.Repository;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public class ProductExchangeService : IProductExchangeService
    {
        private readonly IRepository<ProductExchange> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductExchangeService(IRepository<ProductExchange> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ProductExchangeViewModel productExchangeViewModel)
        {
            // Product product = Mapper.Map<Product>(productViewModel); should use one
            var productExchange = new ProductExchange
            {
                Ten = productExchangeViewModel.Ten,
                Ma = productExchangeViewModel.Ma,
                Menhgia = productExchangeViewModel.Menhgia,
                Loai = productExchangeViewModel.Loai,
                SupplierId = productExchangeViewModel.SupplierId
            };

            await _repository.Create(productExchange);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<ProductExchangeViewModel> GetById(int id)
        {
            return Mapper.Map<ProductExchangeViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<ProductExchangeViewModel>> GetAll()
        {
            return Mapper.Map<List<ProductExchangeViewModel>>(await _repository.GetAll());
        }

        public async Task<bool> IsExisted(string code)
        {
            var productExchange = await _repository.Query(x => x.Ma.ToLower() == code.ToLower()).FirstOrDefaultAsync();
            return productExchange != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(ProductExchangeViewModel productExchangeViewModel)
        {
            var ProductExchangeToUpdate = await _repository.Query(x => x.Id == productExchangeViewModel.Id).FirstOrDefaultAsync();
            Mapper.Map(productExchangeViewModel, ProductExchangeToUpdate);
            await _repository.Update(ProductExchangeToUpdate);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
