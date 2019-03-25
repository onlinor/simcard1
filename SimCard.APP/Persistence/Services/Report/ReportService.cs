using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

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
            List<ExpandoObject> result = new List<ExpandoObject>();
            switch (type)
            {
                case 1:
                    result = await Report_XuatNhapTonTongHop(filter);
                    return result;
                case 2:
                    result = await Report_HangTonKho(filter);
                    return result;
                case 3:
                    result = await Report_NhapHangTheoNhaCungCap(filter);
                    return result;
                case 4:
                    result = await Report_NhapHangTheoMatHang(filter);
                    return result;
                case 5:
                    result = await Report_ChiTietXuatHangVaLoiNhuan(filter);
                    return result;
                case 6:
                    result = await Report_TongHopXuatHangVaLoiNhuanTheoMatHang(filter);
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
                    result = await Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(filter);
                    return result;
                case 11:
                    result = await Report_ChiTietThuChiKhac(filter);
                    return result;
                case 12:
                    result = await Report_TongHopThuChiKhac(filter);
                    return result;
                case 13:
                    result = await Report_ChiTietChiPhiHoatDongKinhDoanh(filter);
                    return result;
                case 14:
                    result = await Report_TongHopChiPhiHoatDongKinhDoanh(filter);
                    return result;
                default:
                    result = await Report_KetQuaKinhDoanh(filter);
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
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            List<Product> products = await _productRepository.Query(p => p.ShopId == 1).Distinct().ToListAsync();
            foreach (Product product in products)
            {
                dynamic line = new List<ExpandoObject>();
                line.matHang = product.Ten;
                line.maHang = product.Ma;
                line.toanCongTy = product.Soluong;
                List<Shop> shops = await _shopRepository.Query(s => true).Include(s => s.Products).ToListAsync();
                foreach (Shop shop in shops)
                {
                    line[shop.Name] = shop.Products.FirstOrDefault(p => p.Id == product.Id).Soluong;
                    line.toanCongTy += (decimal)line[shop.Name];
                }
                result.Add(line);
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now.AddDays(-7);

            IIncludableQueryable<ImportReceipt, List<ImportReceiptProducts>> importReceiptProductsQuery = 
                _importReceiptRepository.Query(ir => ir.DateCreated >= fromDate && ir.DateCreated <= toDate).Include(ir => ir.Products);
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
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterViewModel filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterViewModel filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();

            DateTime fromDate = filter.From ?? DateTime.Now.AddDays(-7);
            DateTime toDate = filter.To ?? DateTime.Now.AddDays(-7);

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
                .Include(er => er.Products).OrderByDescending(er => er.DateCreated).SelectMany(x => x.Products);

            foreach (Product product in products)
            {
                dynamic line = new ExpandoObject();

                // Lần nhập cuối cùng của ngày trước kỳ báo cáo 
                ImportReceipt lastImport = _importReceiptRepository.Query(ir => ir.DateCreated <= fromDate.AddDays(-1))
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).First();
                // Lần xuât cuối cùng của ngày trước kỳ báo cáo 
                ExportReceipt lastExport = _exportReceiptRepository.Query(ir => ir.DateCreated <= fromDate.AddDays(-1))
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).First();
                // Ngày giờ nhập > Ngày giờ xuất => lấy số lượng sau khi nhập 
                int quantityBeginPeriod = lastImport.DateCreated > lastExport.DateCreated ?
                    lastImport.Products.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity :
                    lastExport.Products.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity;

                // Lần nhập cuối cùng của ngày cuối kỳ báo cáo 
                ImportReceipt latestImport = _importReceiptRepository.Query(ir => ir.DateCreated <= toDate)
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).First();
                // Lần xuât cuối cùng của ngày cuối kỳ báo cáo 
                ExportReceipt latestExport = _exportReceiptRepository.Query(ir => ir.DateCreated <= toDate)
                    .Include(ir => ir.Products).OrderByDescending(ir => ir.DateCreated).First();
                // Ngày giờ nhập > Ngày giờ xuất => lấy số lượng sau khi nhập 
                int quantityEndPeriod = latestImport.DateCreated > latestExport.DateCreated ?
                    latestImport.Products.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity :
                    latestExport.Products.Where(p => p.ProductId == product.Id).First().NewWarehouseQuantity;

                line.productCode = product.Ma;
                line.productName = product.Ten;
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
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietThuChiKhac()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietXuatHangVaLoiNhuan()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            List<ProductViewModel> products = Mapper.Map<List<ProductViewModel>>(await _productRepository.Query(p => p.ShopId != null).ToListAsync());
            products.Add(new ProductViewModel
            {
                Id = 0,
                Ma = "ALL",
                Ten = "Tất cả mặt hàng"
            });
            result.shops = shops;
            result.products = products;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_CongNoKhachHangToanCongTy()
        {
            return null;
        }

        private async Task<ExpandoObject> GetFilterData_HangTonKho()
        {
            return null;
        }

        private async Task<ExpandoObject> GetFilterData_KetQuaKinhDoanh()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoMatHang()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoNhaCungCap()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopChiPhiHoatDongKinhDoanh()
        {
            dynamic result = new ExpandoObject();
            List<BankAccountViewModel> bankAccounts = Mapper.Map<List<BankAccountViewModel>>(await _bankAccountRepository.GetAll());
            bankAccounts.Add(new BankAccountViewModel
            {
                Id = 0,
                Name = "Tất cả tài khoản"
            });
            List<SupplierViewModel> suppliers = Mapper.Map<List<SupplierViewModel>>(await _supplierRepository.GetSuppliers());
            suppliers.Add(new SupplierViewModel
            {
                Id = 0,
                Name = "Tất cả nhà cung cấp"
            });
            result.bankAccounts = bankAccounts;
            result.suppliers = suppliers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopCongNoKhachHangTungCN()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy()
        {
            dynamic result = new ExpandoObject();
            List<BankAccountViewModel> bankAccounts = Mapper.Map<List<BankAccountViewModel>>(await _bankAccountRepository.GetAll());
            bankAccounts.Add(new BankAccountViewModel
            {
                Id = 0,
                Name = "Tất cả tài khoản"
            });
            List<SupplierViewModel> suppliers = Mapper.Map<List<SupplierViewModel>>(await _supplierRepository.GetSuppliers());
            suppliers.Add(new SupplierViewModel
            {
                Id = 0,
                Name = "Tất cả nhà cung cấp"
            });
            result.bankAccounts = bankAccounts;
            result.suppliers = suppliers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopThuChiKhac()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang()
        {
            dynamic result = new ExpandoObject();
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            List<CustomerViewModel> customers = Mapper.Map<List<CustomerViewModel>>(await _customerRepository.GetAllCustomers());
            result.shops = shops;
            result.customers = customers;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang()
        {
            dynamic result = new ExpandoObject();
            List<ProductViewModel> products = Mapper.Map<List<ProductViewModel>>(await _productRepository.GetProducts());
            products.Add(new ProductViewModel
            {
                Id = 0,
                Ma = "ALL",
                Ten = "Tất cả mặt hàng"
            });
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.products = products;
            result.shops = shops;
            return result;
        }

        private async Task<ExpandoObject> GetFilterData_XuatNhapTonTongHop()
        {
            dynamic result = new ExpandoObject();
            List<ProductViewModel> products = Mapper.Map<List<ProductViewModel>>(await _productRepository.GetProducts());
            products.Add(new ProductViewModel
            {
                Id = 0,
                Ma = "ALL",
                Ten = "Tất cả mặt hàng"
            });
            List<ShopViewModel> shops = Mapper.Map<List<ShopViewModel>>(await _shopRepository.GetShops());
            result.products = products;
            result.shops = shops;
            return result;
        }
    }
}