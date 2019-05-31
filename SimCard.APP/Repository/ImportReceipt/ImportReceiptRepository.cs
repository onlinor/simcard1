using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public class ImportReceiptRepository : IImportReceiptRepository
    {
        private readonly SimCardDBContext _context;

        public ImportReceiptRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<ImportReceipt> AddImportReceipt(ImportReceiptViewModel importReceiptViewModel)
        {
            if (importReceiptViewModel != null)
            {
                var listImportReceiptProduct = new List<ImportReceiptProducts>();

                foreach (var item in importReceiptViewModel.Products)
                {
                    var p = new ImportReceiptProducts
                    {
                        ChietKhau = (item.Menhgia - item.DonGia.Value) * 100 / item.Menhgia,
                        DateCreated = DateTime.Now,
                        ProductId = _context.Products.First(x => x.Ma == item.Ma).Id,
                        ImportQuantity = item.Soluong,
                        NewWarehouseQuantity = _context.Products.First(x => x.Ma == item.Ma).Soluong
                    };
                    listImportReceiptProduct.Add(p);
                }

                // ImportReceipt importReceipt = Mapper.Map<ImportReceipt>(importReceiptViewModel);
                var importReceipt = new ImportReceipt
                {
                    DateCreated = DateTime.Now,
                    Ma = importReceiptViewModel.Ma,
                    Prefix = importReceiptViewModel.Prefix,
                    Suffix = importReceiptViewModel.Suffix,
                    Nhanvienlap = importReceiptViewModel.NhanVienLap,
                    Congnocu = importReceiptViewModel.CongNoCu,
                    Nguoidaidien = importReceiptViewModel.NguoiDaiDien,
                    Products = listImportReceiptProduct,
                    Sodienthoai = importReceiptViewModel.SoDienThoai,
                    Ghichu = importReceiptViewModel.GhiChu,
                    Tienthanhtoan = importReceiptViewModel.TienThanhToan,
                    Tienconlai = importReceiptViewModel.TienConLai,
                    ShopId = importReceiptViewModel.ShopId,
                    ImmportFromSupplierId = importReceiptViewModel.SupplierId
                };
                await _context.AddAsync(importReceipt);
                await _context.SaveChangesAsync();
                return importReceipt;
            }
            return null;
        }

        public async Task<string> GenerateProductCode()
        {
            string currentDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd").Replace("-", "");
            // No data for new day
            var existingPNs = await _context.ImportReceipts.Where(x => x.Prefix.Replace("PN", "") == currentDate).ToListAsync();
            if (existingPNs.Count() == 0)
            {
                return ("PN" + currentDate + ".1");
            }
            // Already Data in DB, genereated new suffix
            int newSuffix = existingPNs.Max(x => x.Suffix) + 1;
            return ("PN" + currentDate + "." + newSuffix);
        }

        public async Task<List<ImportReceiptViewModel>> GetAllAsync()
        {
            return Mapper.Map<List<ImportReceiptViewModel>>(await _context.ImportReceipts.ToListAsync());
        }

        public async Task<ImportReceiptViewModel> GetByIdAsync(int id)
        {
            return Mapper.Map<ImportReceiptViewModel>(await _context.ImportReceipts.FindAsync(id));
        }

        public async Task<List<ExpandoObject>> GetImportSummary(List<ProductViewModel> productViewModels)
        {
            var result = new List<ExpandoObject>();

            // Where shop id != null => product of shop
            var products = await _context.Products.Where(p => p.ShopId != null).GroupBy(p => p.Ma).ToListAsync();
            foreach (IGrouping<string, ImportReceipt> item in products)
            {
                dynamic keyVal = new ExpandoObject();
                keyVal.Group = item.Key;
                keyVal.Items = Mapper.Map<List<ProductViewModel>>(item);
                result.Add(keyVal);
            }
            return result;
        }

        public IQueryable<ImportReceipt> Query(Expression<Func<ImportReceipt, bool>> predicate)
        {
            return _context.ImportReceipts.Where(predicate);
        }
    }
}