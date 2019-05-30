using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Repositories
{
    public class ExportReceiptRepository : IExportReceiptRepository
    {
        private readonly SimCardDBContext _context;

        public ExportReceiptRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<ExportReceipt> AddExportReceipt(ExportReceiptViewModel exportReceiptViewModel)
        {
            if (exportReceiptViewModel != null)
            {
                var listExportReceiptProduct = new List<ExportReceiptProducts>();

                foreach (ProductViewModel item in exportReceiptViewModel.Products)
                {
                    ExportReceiptProducts p = new ExportReceiptProducts();
                    p.ChietKhau = (item.Menhgia - item.DonGia.Value) * 100 / item.Menhgia;
                    p.DateCreated = DateTime.Now;
                    p.ProductId = _context.Products.First(x => x.Ma == item.Ma).Id;
                    p.ExportQuantity = item.Soluong;
                    p.NewWarehouseQuantity = _context.Products.First(x => x.Ma == item.Ma).Soluong;
                    listExportReceiptProduct.Add(p);
                }

                // ImportReceipt importReceipt = Mapper.Map<ImportReceipt>(importReceiptViewModel);
                ExportReceipt exportReceipt = new ExportReceipt
                {
                    DateCreated = DateTime.Now,
                    Ma = exportReceiptViewModel.Ma,
                    Prefix = exportReceiptViewModel.Prefix,
                    Suffix = exportReceiptViewModel.Suffix,
                    Nhanvienlap = exportReceiptViewModel.NhanVienLap,
                    RepresentativePerson = exportReceiptViewModel.NguoiDaiDien,
                    ExportReceiptProducts = listExportReceiptProduct,
                    PhoneNumber = exportReceiptViewModel.SoDienThoai,
                    Note = exportReceiptViewModel.GhiChu,
                    MoneyPaid = exportReceiptViewModel.TienThanhToan,
                    Debt = exportReceiptViewModel.TienConLai,
                    ShopId = exportReceiptViewModel.ShopId,
                    ExportToShopId = exportReceiptViewModel.ShopId
                };
                await _context.AddAsync(exportReceipt);
                await _context.SaveChangesAsync();
                return exportReceipt;
            }
            return null;
        }

        public async Task<List<ExportReceiptViewModel>> GetAllAsync()
        {
            return Mapper.Map<List<ExportReceiptViewModel>>(await _context.ExportReceipts.ToListAsync());
        }

        public async Task<ExportReceiptViewModel> GetById(int id)
        {
            return Mapper.Map<ExportReceiptViewModel>(await _context.ExportReceipts.FindAsync(id));
        }

        public IQueryable<ExportReceipt> Query(Expression<Func<ExportReceipt, bool>> predicate)
        {
            return _context.ExportReceipts.Where(predicate);
        }

        public async Task<string> GenerateProductCode()
        {
            string currentDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd").Replace("-", "");
            // No data for new day
            List<ExportReceipt> existingPNs = await _context.ExportReceipts.Where(x => x.Prefix.Replace("PX", "") == currentDate).ToListAsync();
            if (existingPNs.Count() == 0)
            {
                return ("PX" + currentDate + ".1");
            }
            // Already Data in DB, genereated new suffix
            int newSuffix = existingPNs.Max(x => x.Suffix) + 1;
            return ("PX" + currentDate + "." + newSuffix);
        }
    }
}
