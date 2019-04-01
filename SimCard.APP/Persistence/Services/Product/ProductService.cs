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
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ProductViewModel productViewModel)
        {
            // Product product = Mapper.Map<Product>(productViewModel); should use one
            Product product = new Product
            {
                Ten = productViewModel.Ten,
                Ma = productViewModel.Ma,
                Menhgia = productViewModel.Menhgia,
                Soluong = productViewModel.Soluong,
                DonGia = productViewModel.DonGia,
                ShopId = productViewModel.ShopId,
                SupplierId = productViewModel.SupplierId
            };

            if (product.ShopId != 1)
            {
                Product MainProduct = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                MainProduct.Soluong = MainProduct.Soluong - productViewModel.Soluong;
                await _repository.Update(MainProduct);
                if (MainProduct.Soluong == 0)
                {
                    await _repository.Remove(MainProduct.Id);
                }
                else
                {
                    await _repository.Update(MainProduct);
                }
            }
            await _repository.Create(product);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            return Mapper.Map<ProductViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return Mapper.Map<List<ProductViewModel>>(await _repository.Query(x => x.ShopId == 1).ToListAsync());
        }

        public async Task<bool> IsExisted(string code, int? shopId)
        {
            Product product = await _repository.Query(x => x.Ma.ToLower() == code.ToLower() && x.ShopId == shopId).FirstOrDefaultAsync();
            return product != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(ProductViewModel productViewModel)
        {
            Product ProductToUpdate = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == productViewModel.ShopId).FirstOrDefaultAsync();
            ProductToUpdate.Soluong += productViewModel.Soluong;
            if (ProductToUpdate.ShopId != 1)
            {
                Product MainProduct = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                MainProduct.Soluong = MainProduct.Soluong - productViewModel.Soluong;
                if (MainProduct.Soluong == 0)
                {
                    await _repository.Remove(MainProduct.Id);
                }
                else
                {
                    await _repository.Update(MainProduct);
                }
            }
            await _repository.Update(ProductToUpdate);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
