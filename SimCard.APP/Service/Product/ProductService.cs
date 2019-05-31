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
            var product = new Product
            {
                Ten = productViewModel.Ten,
                Ma = productViewModel.Ma,
                Menhgia = productViewModel.Menhgia,
                Soluong = productViewModel.Soluong,
                DonGia = productViewModel.DonGia,
                ShopId = productViewModel.ShopId,
                Loai = productViewModel.Loai,
                SupplierId = productViewModel.SupplierId
            };

            if (product.ShopId != 1)
            {
                var p = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                p.Soluong = p.Soluong - productViewModel.Soluong;
                await _repository.Update(p);
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
            var product = await _repository.Query(x => x.Ma.ToLower() == code.ToLower() && x.ShopId == shopId).FirstOrDefaultAsync();
            return product != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(ProductViewModel productViewModel)
        {
            var product = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == productViewModel.ShopId).FirstOrDefaultAsync();
            if (product.ShopId == 1 && product.Soluong == 0)
            {
                product.Soluong += productViewModel.Soluong;
                product.DonGia = productViewModel.DonGia;
            }
            else
            {
                product.Soluong += productViewModel.Soluong;
                if (product.ShopId != 1)
                {
                    var p = await _repository.Query(x => x.Ma.ToLower() == productViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                    p.Soluong -= productViewModel.Soluong;
                    await _repository.Update(p);
                }
            }
            await _repository.Update(product);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
