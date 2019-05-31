using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SimCardDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(SimCardDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProducts(List<ProductViewModel> productViewModels)
        {
            foreach (var item in productViewModels)
            {
                if (await IsProductExists(item.Ma))
                {
                    var p = await _context.Products.FirstAsync(x => (x.Ma.ToLower() == item.Ma.ToLower()) && (x.ShopId.Value == item.ShopId.Value));
                    p.Soluong += item.Soluong;
                    p.DateModified = DateTime.Now;
                    _context.Products.Update(p);
                }
                else
                {
                    var product = new Product
                    {
                        DateCreated = DateTime.Now,
                        Ten = item.Ten,
                        Ma = item.Ma,
                        Menhgia = item.Menhgia,
                        Soluong = item.Soluong,
                        DonGia = item.DonGia,
                        ShopId = item.ShopId,
                        SupplierId = item.SupplierId
                    };
                    await _context.Products.AddAsync(product);
                }
            }
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            return Mapper.Map<ProductViewModel>(await _context.Products.FindAsync(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return Mapper.Map<List<ProductViewModel>>(await _context.Products.Where(x => x.ShopId == 1).ToListAsync());
        }

        public async Task<bool> IsProductExists(string code)
        {
            return await _context.Products.AnyAsync(x => (x.Ma.ToLower() == code.ToLower()));
        }

        public async Task<bool> Remove(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _unitOfWork.SaveChangeAsync();
            }
            return false;
        }

        public IQueryable<Product> Query(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }

        public async Task<bool> UpdateProduct(ProductViewModel productViewModel)
        {
            var product = await _context.Products.FindAsync(productViewModel.Id);
            if (product != null)
            {
                Mapper.Map(productViewModel, product);
                _context.Products.Update(product);
                return await _unitOfWork.SaveChangeAsync();
            }
            return false;
        }
    }
}