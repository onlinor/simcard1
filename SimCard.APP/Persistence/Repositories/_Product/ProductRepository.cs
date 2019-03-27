using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
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

        public async Task<bool> AddProduct(ProductViewModel productViewModel)
        {
            if (await IsProductExists(productViewModel.Ma))
            {
                Product p = await _context.Products.FirstAsync(x => x.Ma.ToLower() == productViewModel.Ma.ToLower());
                p.Soluong = p.Soluong + productViewModel.Soluong;
                _context.Products.Update(p);
            }
            else
            {
                Product product = Mapper.Map<Product>(productViewModel);
                await _context.Products.AddAsync(product);
            }
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> AddProducts(List<ProductViewModel> productViewModels)
        {
            foreach (ProductViewModel item in productViewModels)
            {
                if (await IsProductExists(item.Ma))
                {
                    Product p = await _context.Products.FirstAsync(x => x.Ma.ToLower() == item.Ma.ToLower());
                    p.Soluong = p.Soluong + item.Soluong;
                    p.DateModified = DateTime.Now;
                    _context.Products.Update(p);
                }
                else
                {   
                    Product product = new Product
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
            return await _context.Products.AnyAsync(x => x.Ma.ToLower() == code.ToLower());
        }

        public async Task<bool> Remove(int id)
        {
            Product product = await _context.Products.FindAsync(id);
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
            Product product = await _context.Products.FindAsync(productViewModel.Id);
            if (product != null)
            {
                Mapper.Map(productViewModel, product);
                _context.Products.Update(product);
                return await _unitOfWork.SaveChangeAsync();
            }
            return false;
        }

        /* public async Task<List<ExpandoObject>> GetAllProductsGroupByType()
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            List<IGrouping<string, ImportReceipt>> products = await _context.Products.GroupBy(p => p.ProductType).ToListAsync();
            foreach (IGrouping<string, ImportReceipt> item in products)
            {
                dynamic keyVal = new ExpandoObject();
                keyVal.Group = item.Key;
                keyVal.Items = Mapper.Map<List<ProductViewModel>>(item);
                result.Add(keyVal);
            }
            return result;
        } */
    }
}