using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
namespace SimCard.APP.Persistence.Services
{
    public class ReportService : IReportService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICashbookRepository _cashbookRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShopRepository _shopRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IExportReceiptRepository _exportReceiptRepository;

        public ReportService(
            IProductRepository productRepository,
            ICashbookRepository cashbookRepository,
            IBankAccountRepository bankAccountRepository,
            ICustomerRepository customerRepository,
            IShopRepository shopRepository,
            ISupplierRepository supplierRepository,
            IImportReceiptRepository importReceiptRepository,
            IExportReceiptRepository exportReceiptRepository)
        {
            _productRepository = productRepository;
            _cashbookRepository = cashbookRepository;
            _bankAccountRepository = bankAccountRepository;
            _customerRepository = customerRepository;
            _shopRepository = shopRepository;
            _supplierRepository = supplierRepository;
            _importReceiptRepository = importReceiptRepository;
            _exportReceiptRepository = exportReceiptRepository;
        }

        public async Task<List<ExpandoObject>> GetReport(int type, ReportFilterViewModel filter)
        {
            List<ExpandoObject> result;
            switch (type)
            {
                case 1:
                    result = await Report_XuatNhapTonTongHop(filter); //done
                    return result;
                case 2:
                    result = await Report_HangTonKho(filter); //done
                    return result;
                case 3:
                    result = await Report_NhapHangTheoNhaCungCap(filter); //done
                    return result;
                case 4:
                    result = await Report_NhapHangTheoMatHang(filter); //done
                    return result;
                case 5:
                    result = await Report_ChiTietXuatHangVaLoiNhuan(filter); //done
                    return result;
                case 6:
                    result = await Report_TongHopXuatHangVaLoiNhuanTheoMatHang(filter); //done
                    return result;
                case 7:
                    result = await Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(filter);
                    return result;
                case 8:
                    result = await Report_CongNoKhachHangToanCongTy(filter);
                    return result;
                case 9:
                    result = await Report_TongHopCongNoKhachHangToanTungCN(filter);
                    return result;
                case 10:
                    result = await Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(filter); //done
                    return result;
                case 11:
                    result = await Report_ChiTietThuChiKhac(filter); //done
                    return result;
                case 12:
                    result = await Report_TongHopThuChiKhac(filter); //done
                    return result;
                case 13:
                    result = await Report_ChiTietChiPhiHoatDongKinhDoanh(filter); //done
                    return result;
                case 14:
                    result = await Report_TongHopChiPhiHoatDongKinhDoanh(filter); //done
                    return result;
                case 15:
                    result = await Report_SoTienMatToanCongTy(filter); //done
                    return result;
                default:
                    result = await Report_KetQuaKinhDoanh(filter); //done, TODO: calculate line.chiPhiKhac
                    return result;
            }
        }

        public async Task<ExpandoObject> GetFilterData(int type)
        {
            ExpandoObject result = new ExpandoObject();
            switch (type)
            {
                case 1:
                    result = await GetFilterData_XuatNhapTonTongHop();
                    return result;
                case 2:
                    result = await GetFilterData_HangTonKho();
                    return result;
                case 3:
                    result = await GetFilterData_NhapHangTheoNhaCungCap();
                    return result;
                case 4:
                    result = await GetFilterData_NhapHangTheoMatHang();
                    return result;
                case 5:
                    result = await GetFilterData_ChiTietXuatHangVaLoiNhuan();
                    return result;
                case 6:
                    result = await GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang();
                    return result;
                case 7:
                    result = await GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang();
                    return result;
                case 8:
                    result = await GetFilterData_CongNoKhachHangToanCongTy();
                    return result;
                case 9:
                    result = await GetFilterData_TongHopCongNoKhachHangTungCN();
                    return result;
                case 10:
                    result = await GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy();
                    return result;
                case 11:
                    result = await GetFilterData_ChiTietThuChiKhac();
                    return result;
                case 12:
                    result = await GetFilterData_TongHopThuChiKhac();
                    return result;
                case 13:
                    result = await GetFilterData_ChiTietChiPhiHoatDongKinhDoanh();
                    return result;
                case 14:
                    result = await GetFilterData_TongHopChiPhiHoatDongKinhDoanh();
                    return result;
                default:
                    result = await GetFilterData_KetQuaKinhDoanh();
                    return result;
            }
        }


        // Function to get report

        private async Task<List<ExpandoObject>> Report_ChiTietChiPhiHoatDongKinhDoanh(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var cashBooks = _cashbookRepository.Query(er => true);
            if (filter.Shop != 0)
            {
                cashBooks = cashBooks.Include(c => c.Shop).Where(s => s.ShopId == filter.Shop).Where(c => c.DateCreated >= fromDate && c.DateCreated <= toDate);
            }
            var listCashbook = await cashBooks.ToListAsync();
            foreach (var cashbook in listCashbook)
            {
                dynamic line = new ExpandoObject();

                line.chiNhanh = cashbook.Shop.Name;
                line.ngayThang = cashbook.DateCreated;
                line.phieuThuChi = cashbook.SoTienChi > 0 ? "Thu" : "Chi";
                line.noiDung = cashbook.NoiDungPhieu;
                line.soThu = cashbook.SoTienThu;
                line.soChi = cashbook.SoTienChi;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var exportReceipts = await _exportReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).ToListAsync();
            var importReceipts = await _importReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).ToListAsync();

            foreach (var ir in importReceipts)
            {
                dynamic line = new ExpandoObject();

                line.ngayThang = ir.DateCreated;
                line.noiDung = ir.Nhanvienlap;
                line.thuKhac = ir.Tienthanhtoan;
                line.chiKhac = 0;

                result.Add(line);
            }
            foreach (var er in exportReceipts)
            {
                dynamic line = new ExpandoObject();

                line.ngayThang = er.DateCreated;
                line.noiDung = er.Nhanvienlap;
                line.thuKhac = 0;
                line.chiKhac = er.MoneyPaid;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            IQueryable<Product> productsQuery = _productRepository.Query(p => p.SupplierId == null);
            IQueryable<ExportReceipt> exportReceiptsQuery = _exportReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate);

            if (filter.Shop != 0) // Chi nhánh
            {
                productsQuery = productsQuery.Where(p => p.ShopId == filter.Shop);
                exportReceiptsQuery = exportReceiptsQuery.Where(er => er.ShopId == filter.Shop);
            }

            if (filter.Product != 0) // Mat hang
            {
                productsQuery = productsQuery.Where(p => p.Id == filter.Product);
            }
            var erportReceiptProducts = await exportReceiptsQuery.Include(er => er.ExportReceiptProducts).ThenInclude(navigationPropertyPath: e => e.Product).ToListAsync();
            foreach (var er in erportReceiptProducts)
            {
                foreach (var erp in er.ExportReceiptProducts)
                {
                    dynamic line = new ExpandoObject();
                    line.ngayXuat = er.DateCreated;
                    line.maHang = erp.Product.Ma;
                    if (er.ExportToCustomerId != null)
                    {
                        var customer = await _customerRepository.GetCustomer((int)er.ExportToCustomerId);
                        line.khacHang = customer.HoTen;
                    }
                    else
                    {
                        var shop = await _shopRepository.GetShop((int)er.ExportToShopId);
                        line.khacHang = shop.Name;
                    }
                    line.phieuNhap = er.Prefix + er.Suffix;
                    line.soLuong = erp.ExportQuantity;
                    line.chietKhauDauVao = erp.ChietKhau;
                    line.chietKhauDauRa = erp.ChietKhau;
                    line.giaDauVao = erp.Product.DonGia;
                    line.giaDauRa = erp.Product.Menhgia * (100 - erp.ChietKhau) / 100;

                    result.Add(line);
                }
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var custopmers = await _customerRepository.GetAllCustomers();
            foreach (var customer in custopmers)
            {
                dynamic line = new ExpandoObject();

                line.khachHang = customer.HoTen;
                line.maKhachHang = customer.MaKH;
                line.noKhach = customer.MaKH;
                line.khachNo = customer.MaKH;
                line.congDon = customer.MaKH;
                line.chiTietPhieu = customer.MaKH;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            List<Product> products = await _productRepository.Query(p => p.ShopId == 1).Distinct().ToListAsync();
            foreach (Product product in products)
            {
                dynamic line = new ExpandoObject();
                line.matHang = product.Ten;
                line.maHang = product.Ma;
                line.toanCongTy = product.Soluong;
                List<Shop> shops = await _shopRepository.Query(s => true).Include(s => s.Products).ToListAsync();
                foreach (Shop shop in shops)
                {
                    var shopProduct = shop.Products.FirstOrDefault(p => p.Id == product.Id);
                    ((IDictionary<string, Object>)line)[shop.Name] = shopProduct != null ? shopProduct.Soluong : 0;
                    line.toanCongTy += (int)((IDictionary<string, Object>)line)[shop.Name];
                }
                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var shops = _shopRepository.Query(s => true);

            if (filter.Shop > 0)
            {
                shops = shops.Where(s => s.Id == filter.Shop).Include(s => s.ImportReceipts).Include(s => s.ExportReceipts).Include(s => s.Cashbooks);
            }
            var listShops = await shops.ToListAsync();

            foreach (var shop in listShops)
            {
                dynamic line = new ExpandoObject();

                line.chiNhanh = shop.Name;
                line.loiNhuanBanHang =
                    shop.ExportReceipts.Where(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).Sum(er => er.MoneyPaid) -
                    shop.ImportReceipts.Where(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).Sum(er => er.Tienthanhtoan);
                line.loiNhuanKhac =
                    shop.Cashbooks.Where(c => c.DateCreated >= fromDate && c.DateCreated <= toDate).Sum(c => c.SoTienThu) -
                    shop.Cashbooks.Where(c => c.DateCreated >= fromDate && c.DateCreated <= toDate).Sum(c => c.SoTienChi);
                line.tongLoiNhuan = line.loiNhuanBanHang + line.loiNhuanKhac;
                line.chiPhiBanHang = 0;
                line.loiNhuanThuc = line.tongLoiNhuan - line.chiPhiBanHang;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            var fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            var toDate = filter.To ?? DateTime.Now;

            var importReceiptProductsQuery = _importReceiptRepository.Query(ir => ir.DateCreated >= fromDate && ir.DateCreated <= toDate).Include(ir => ir.Products);
            if (filter.Shop != 0)
            {
                var products = await importReceiptProductsQuery.Where(ir => ir.ShopId == filter.Shop).SelectMany(ir => ir.Products).Include(p => p.Product)
                    .Select(p => new { p.ImportQuantity, p.Product.Ma, p.Product.Ten, p.ChietKhau, p.Product.DonGia }).GroupBy(p => p.Ma).ToListAsync();
                foreach (var group in products)
                {
                    dynamic line = new ExpandoObject();
                    line.maHang = group.Key;
                    line.tenHang = group.First().Ten;
                    line.chietKhau = group.Average(p => p.ChietKhau);
                    line.giaNhap = group.Average(p => p.DonGia);
                    line.soLuong = group.Sum(p => p.ImportQuantity);
                    result.Add(line);
                }
            }
            else
            {
                var products = await importReceiptProductsQuery.SelectMany(ir => ir.Products).Include(p => p.Product)
                    .Select(p => new { p.ImportQuantity, p.Product.Ma, p.Product.Ten, p.ChietKhau, p.Product.DonGia }).GroupBy(p => p.Ma).ToListAsync();
                foreach (var group in products)
                {
                    dynamic line = new ExpandoObject();
                    line.maHang = group.Key;
                    line.tenHang = group.First().Ten;
                    line.chietKhau = group.Average(p => p.ChietKhau);
                    line.giaNhap = group.Average(p => p.DonGia);
                    line.soLuong = group.Sum(p => p.ImportQuantity);
                    result.Add(line);
                }
            }

            return result;
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoNhaCungCap(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            var fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            var toDate = filter.To ?? DateTime.Now;

            var importReceiptsQuery = _importReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate);

            if (filter.Supplier != 0) // Chi nhánh
            {
                importReceiptsQuery = importReceiptsQuery.Where(er => er.ImmportFromSupplierId == filter.Supplier);
            }

            var importRecepts = await importReceiptsQuery.Include(ir => ir.Products).ThenInclude(irp => irp.Product).ToListAsync();
            var suppliers = await _supplierRepository.GetSuppliers();
            var lines = from importRecept in importRecepts
                        join supplier in suppliers on importRecept.ImmportFromSupplierId equals supplier.Id
                        select new
                        {
                            ngayNhap = importRecept.DateCreated,
                            nhaCC = supplier.Name,
                            phieuNhap = importRecept.Prefix + importRecept.Suffix,
                            matHang = importRecept.Products
                        };
            foreach (var line in lines)
            {
                foreach (var product in line.matHang)
                {
                    dynamic rline = new ExpandoObject();

                    rline.ngayNhap = line.ngayNhap;
                    rline.nhaCC = line.nhaCC;
                    rline.phieuNhap = line.phieuNhap;
                    rline.matHang = product.ProductId;
                    rline.chietKhau = product.ChietKhau;
                    rline.giaNhap = product.Product.Menhgia;
                    rline.soLuong = product.ImportQuantity;
                    rline.thanhTien = rline.soLuong * rline.donGiaNhap;
                    result.Add(rline);
                }
            }

            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var exportReceipts = await _exportReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).ToListAsync();
            var importReceipts = await _importReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate).ToListAsync();

            var shops = await _shopRepository.Query(s => true)
                .Include(s => s.ImportReceipts)
                .Include(s => s.ExportReceipts).ToListAsync();

            if (filter.Shop != 0)
            {
                shops = shops.Where(s => s.Id == filter.Shop).ToList();
            }

            foreach (var shop in shops)
            {
                dynamic line = new ExpandoObject();
                line.soThu = shop.ImportReceipts.Sum(ir => ir.Tienthanhtoan);
                line.soChi = shop.ExportReceipts.Sum(er => er.MoneyPaid);
            }

            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var custopmers = await _customerRepository.GetAllCustomers();
            foreach (var customer in custopmers)
            {
                dynamic line = new ExpandoObject();

                line.khachHang = customer.HoTen;
                line.maKhachHang = customer.MaKH;
                line.noKhach = customer.MaKH;
                line.khachNo = customer.MaKH;
                line.congDon = customer.MaKH;
                line.chiTietPhieu = customer.MaKH;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var cashbooks = await _cashbookRepository.Query(c => c.DateCreated >= fromDate && c.DateCreated <= toDate).ToListAsync();
            foreach (var cashbook in cashbooks)
            {
                dynamic line = new ExpandoObject();

                line.nganHang = cashbook.LoaiNganHang;
                line.soTK = cashbook.LoaiNganHang;
                line.noiDung = cashbook.NoiDungPhieu;
                line.thuKhac = cashbook.SoTienThu;
                line.chiKhac = cashbook.SoTienChi;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var shops = await _shopRepository.Query(s => true).Include(s => s.Cashbooks).ToListAsync();

            if (filter.Shop != 0)
            {
                shops = shops.Where(s => s.Id == filter.Shop && s.DateCreated >= fromDate && s.DateCreated <= toDate).ToList();
            }

            foreach (var shop in shops)
            {
                dynamic line = new ExpandoObject();
                line.chiNhanh = shop.Name;
                line.thuKhac = shop.Cashbooks.Where(c => c.MaPhanBo == "TCK").Sum(c => c.SoTienThu);
                line.chiKhac = shop.Cashbooks.Where(c => c.MaPhanBo == "TCK").Sum(c => c.SoTienChi);
                line.loiNhuanKhac = line.thuKhac - line.chiKhac;
            }

            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var custopmers = await _customerRepository.GetAllCustomers();
            foreach (var customer in custopmers)
            {
                dynamic line = new ExpandoObject();

                line.khachHang = customer.HoTen;
                line.maKhachHang = customer.MaKH;
                line.noKhach = customer.MaKH;
                line.khachNo = customer.MaKH;
                line.congDon = customer.MaKH;
                line.chiTietPhieu = customer.MaKH;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_SoTienMatToanCongTy(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            var shops = _shopRepository.Query(s => true);
            if (filter.Shop > 0)
            {
                shops = shops.Where(s => s.Id == filter.Shop);
            }
            var listShop = await shops.Include(s => s.Cashbooks).ToListAsync();
            foreach (var shop in listShop)
            {
                dynamic line = new ExpandoObject();
                var soThu = shop.Cashbooks.Where(c => c.MaPhanBo == "TCK" && c.SoTienThu > 0);
                var soChi = shop.Cashbooks.Where(c => c.MaPhanBo == "TCK" && c.SoTienChi > 0);

                line.chiNhanh = shop.Name;
                line.diaChi = shop.Address;
                line.giamDoc = shop.Director;
                line.soThu = soThu != null ? soThu.Sum(c => c.SoTienThu) : 0;
                line.soChi = soChi != null ? soChi.Sum(c => c.SoTienChi) : 0;
                line.congDon = line.soThu - line.soChi;

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterViewModel filter)
        {

            List<ExpandoObject> result = new List<ExpandoObject>();

            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;
            IQueryable<Product> productsQuery = _productRepository.Query(p => p.SupplierId == null);
            IQueryable<ImportReceipt> importReceiptsQuery = _importReceiptRepository.Query(ir => ir.DateCreated >= fromDate && ir.DateCreated <= toDate);
            IQueryable<ExportReceipt> exportReceiptsQuery = _exportReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate);

            if (filter.Shop != 0) // Chi nhánh
            {
                productsQuery = productsQuery.Where(p => p.ShopId == filter.Shop);
                exportReceiptsQuery = exportReceiptsQuery.Where(er => er.ShopId == filter.Shop);
            }

            if (filter.Product != 0) // Mat hang
            {
                productsQuery = productsQuery.Where(p => p.Id == filter.Product);
            }
            List<Product> products = await productsQuery.ToListAsync();
            IQueryable<ImportReceiptProducts> importProductList = importReceiptsQuery.Include(ir => ir.Products)
                .OrderByDescending(ir => ir.DateCreated).SelectMany(x => x.Products);
            IQueryable<ExportReceiptProducts> exportProductList = exportReceiptsQuery.Include(er => er.ExportReceiptProducts).OrderByDescending(er => er.DateCreated)
                .SelectMany(x => x.ExportReceiptProducts).Include(l => l.ExportReceipt).Include(l => l.Product);

            foreach (Product product in products)
            {
                dynamic line = new ExpandoObject();

                line.maHang = product.Ma;
                line.tenHang = product.Ten;
                line.doanhThuBanHang = exportProductList.Sum(er => er.ExportQuantity * er.Product.DonGia);
                line.doanhThuNoiBo = exportProductList.Where(er => er.ExportReceipt.ExportToShopId != null).Sum(er => er.ExportQuantity * er.Product.DonGia);
                line.doanhThuThuc = line.doanhThuBanHang - line.doanhThuNoiBo;
                line.loiNhuan = line.doanhThuThuc - importProductList.Where(ir => ir.ProductId == product.Id).Sum(ir => ir.ImportQuantity * product.Menhgia);

                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();

            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now;

            IQueryable<Product> productsQuery = _productRepository.Query(p => p.SupplierId == null);
            IQueryable<ImportReceipt> importReceiptsQuery = _importReceiptRepository.Query(ir => ir.DateCreated >= fromDate && ir.DateCreated <= toDate);
            IQueryable<ExportReceipt> exportReceiptsQuery = _exportReceiptRepository.Query(er => er.DateCreated >= fromDate && er.DateCreated <= toDate);

            if (filter.Shop != 0) // Chi nhánh
            {
                productsQuery = productsQuery.Where(p => p.ShopId == filter.Shop);
                importReceiptsQuery = importReceiptsQuery.Where(ir => ir.ShopId == filter.Shop);
                exportReceiptsQuery = exportReceiptsQuery.Where(er => er.ShopId == filter.Shop);
            }

            if (filter.Product != 0) // Mat hang
            {
                productsQuery = productsQuery.Where(p => p.Id == filter.Product);
            }

            List<Product> products = await productsQuery.ToListAsync();
            IQueryable<ImportReceiptProducts> importProductList = importReceiptsQuery.Include(ir => ir.Products)
                .OrderByDescending(ir => ir.DateCreated).SelectMany(x => x.Products);
            IQueryable<ExportReceiptProducts> exportProductList = exportReceiptsQuery
                .Include(er => er.ExportReceiptProducts).OrderByDescending(er => er.DateCreated).SelectMany(x => x.ExportReceiptProducts);

            foreach (Product product in products)
            {
                dynamic line = new ExpandoObject();

                // Lần nhập cuối cùng của ngày trước kỳ báo cáo 
                ImportReceipt lastImport = await _importReceiptRepository.Query(ir => ir.DateCreated <= fromDate.AddDays(-1))
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).FirstOrDefaultAsync();
                // Lần xuât cuối cùng của ngày trước kỳ báo cáo 
                ExportReceipt lastExport = await _exportReceiptRepository.Query(ir => ir.DateCreated <= fromDate.AddDays(-1))
                    .Include(ir => ir.ExportReceiptProducts).OrderByDescending(ir => ir.DateCreated).FirstOrDefaultAsync();

                // Ngày giờ nhập > Ngày giờ xuất => lấy số lượng sau khi nhập
                int quantityLastImport = lastImport != null ? lastImport.Products.Where(p => p.ProductId == product.Id).FirstOrDefault().NewWarehouseQuantity : 0;
                int quantityLastExport = lastExport != null ? lastExport.ExportReceiptProducts.Where(p => p.ProductId == product.Id).FirstOrDefault().NewWarehouseQuantity : 0;

                int quantityBeginPeriod = lastImport.DateCreated > lastExport.DateCreated ? quantityLastImport : quantityLastExport;

                // Lần nhập cuối cùng của ngày cuối kỳ báo cáo 
                ImportReceipt latestImport = await _importReceiptRepository.Query(ir => ir.DateCreated <= toDate)
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).FirstOrDefaultAsync();
                // Lần xuât cuối cùng của ngày cuối kỳ báo cáo 
                ExportReceipt latestExport = await _exportReceiptRepository.Query(ir => ir.DateCreated <= toDate)
                    .Include(ir => ir.ExportReceiptProducts).OrderByDescending(ir => ir.DateCreated).FirstOrDefaultAsync();
                // Ngày giờ nhập > Ngày giờ xuất => lấy số lượng sau khi nhập 
                int quantityEndPeriod = latestImport.DateCreated > latestExport.DateCreated ?
                    latestImport.Products.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity :
                    latestExport.ExportReceiptProducts.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity;

                line.maHang = product.Ma;
                line.tenHang = product.Ten;
                line.tonDauKy = quantityBeginPeriod;
                line.thanhTienTonDauKy = quantityBeginPeriod * product.DonGia;
                line.nhapTrongKy = importProductList.Where(ip => ip.ProductId == product.Id).Sum(p => p.ImportQuantity);
                line.thanhTienNhap = importProductList.Where(ip => ip.ProductId == product.Id).Sum(p => p.ImportQuantity * product.DonGia);
                line.xuatTrongKy = exportProductList.Where(ip => ip.ProductId == product.Id).Sum(p => p.ExportQuantity);
                line.thanhTienXuat = exportProductList.Where(ip => ip.ProductId == product.Id).Sum(p => p.ExportQuantity * product.Menhgia);
                line.tonCuoiKy = quantityEndPeriod;
                line.thanhTienTonCuoiKy = quantityEndPeriod * product.DonGia;

                result.Add(line);
            }
            return result;
        }

        // Function to get filter data

        private async Task<ExpandoObject> GetFilterData_ChiTietChiPhiHoatDongKinhDoanh()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietThuChiKhac()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietXuatHangVaLoiNhuan()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            var products = (await _productRepository.Query(p => p.ShopId != null).ToListAsync()).Select(p => new { label = p.Ten, value = p.Id }).ToList();
            products.Add(all);
            result.shops = shops;
            result.products = products;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_CongNoKhachHangToanCongTy()
        {
            return new ExpandoObject();
        }

        private async Task<ExpandoObject> GetFilterData_HangTonKho()
        {
            return new ExpandoObject();
        }

        private async Task<ExpandoObject> GetFilterData_KetQuaKinhDoanh()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoMatHang()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoNhaCungCap()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopChiPhiHoatDongKinhDoanh()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var bankAccounts = (await _bankAccountRepository.GetAll()).Select(s => new { label = s.Name, value = s.Id }).ToList().Add(all);
            bankAccounts.Add(all);
            var suppliers = (await _supplierRepository.GetSuppliers()).Select(s => new { label = s.Name, value = s.Id }).ToList().Add(all);
            suppliers.Add(all);
            result.bankAccounts = bankAccounts;
            result.suppliers = suppliers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopCongNoKhachHangTungCN()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var bankAccounts = (await _bankAccountRepository.GetAll()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            bankAccounts.Add(all);
            var suppliers = (await _supplierRepository.GetSuppliers()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            suppliers.Add(all);

            result.bankAccounts = bankAccounts;
            result.suppliers = suppliers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopThuChiKhac()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            var customers = (await _customerRepository.GetAllCustomers()).Select(s => new { label = s.HoTen, value = s.Id }).ToList();
            customers.Add(all);
            result.shops = shops;
            result.customers = customers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var products = (await _productRepository.GetProducts()).Select(s => new { label = s.Ten, value = s.Id }).ToList();
            products.Add(all);
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.products = products;
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_XuatNhapTonTongHop()
        {
            dynamic result = new ExpandoObject();
            dynamic all = new { label = "All", value = 0 };
            var products = (await _productRepository.GetProducts()).Select(s => new { label = s.Ten, value = s.Id }).ToList();
            products.Add(all);
            var shops = (await _shopRepository.GetShops()).Select(s => new { label = s.Name, value = s.Id }).ToList();
            shops.Add(all);
            result.products = products;
            result.shops = shops;
            return result;
        }
    }
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously