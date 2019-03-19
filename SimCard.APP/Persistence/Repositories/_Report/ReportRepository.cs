using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Controllers.Resources;
using SimCard.API.Persistence.Repositories;
using SimCard.API.Persistence.Repositories._Product;
using SimCard.API.Persistence.Repositories._Shop;
using SimCard.API.Persistence.Repositories._Supplier;
using SimCard.APP.Controllers.Resources;

namespace SimCard.API.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly ICashbookRepository _cashbookRepository;
        private readonly IBankbookRepository _bankbookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShopRepository _shopRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ReportRepository(
            IProductRepository productRepository,
            ICashbookRepository cashbookRepository,
            IBankbookRepository bankbookRepository,
            ICustomerRepository customerRepository,
            IShopRepository shopRepository,
            ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _cashbookRepository = cashbookRepository;
            _bankbookRepository = bankbookRepository;
            _customerRepository = customerRepository;
            _shopRepository = shopRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<List<ExpandoObject>> GetReport(int type, ReportFilterResource filter)
        {
            var result = new List<ExpandoObject>();
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
            var result = new ExpandoObject();
            switch (type)
            {
                case 1:
                    result = await GetFilterData_ChiTietChiPhiHoatDongKinhDoanh();
                    return result;
                case 2:
                    result = await GetFilterData_ChiTietThuChiKhac();
                    return result;
                case 3:
                    result = await GetFilterData_ChiTietXuatHangVaLoiNhuan();
                    return result;
                case 4:
                    result = await GetFilterData_CongNoKhachHangToanCongTy();
                    return result;
                case 5:
                    result = await GetFilterData_HangTonKho();
                    return result;
                case 6:
                    result = await GetFilterData_KetQuaKinhDoanh();
                    return result;
                case 7:
                    result = await GetFilterData_NhapHangTheoMatHang();
                    return result;
                case 8:
                    result = await GetFilterData_NhapHangTheoNhaCungCap();
                    return result;
                case 9:
                    result = await GetFilterData_TongHopChiPhiHoatDongKinhDoanh();
                    return result;
                case 10:
                    result = await GetFilterData_TongHopCongNoKhachHangToanTungCN();
                    return result;
                case 11:
                    result = await GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy();
                    return result;
                case 12:
                    result = await GetFilterData_TongHopThuChiKhac();
                    return result;
                case 13:
                    result = await GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang();
                    return result;
                case 14:
                    result = await GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang();
                    return result;
                default:
                    result = await GetFilterData_XuatNhapTonTongHop();
                    return result;
            }
        }

        // Function to get report

        private async Task<List<ExpandoObject>> Report_ChiTietChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterResource filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            var products = await _productRepository.GetProducts();
            foreach (var product in products)
            {
/*                 dynamic line = new List<ExpandoObject>();
                line.MatHang = product.Name;
                line.MaHang = product.Id;
                line.SoLuongToanCongTy = 0;
                var shops = await _shopRepository.Query(s => true).Include(s => s.).ToListAsync();
                foreach (var shop in shops)
                {
                    line[shop.Name] = shop.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                }
                result.Add(line) */;
            }
            return result;
        }

        private async Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoNhaCungCap(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        private async Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterResource filter)
        {
            dynamic result = new ExpandoObject();
            if (filter.Shop != 0) // Chi nhánh
            {
                
            }
            else // Toàn công ty
            {

            }
            return result;
        }

        // Function to get filter data

        private async Task<ExpandoObject> GetFilterData_ChiTietChiPhiHoatDongKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietThuChiKhac()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_ChiTietXuatHangVaLoiNhuan()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_CongNoKhachHangToanCongTy()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_HangTonKho()
        {
            // No filter data needed
            return null;
        }

        private async Task<ExpandoObject> GetFilterData_KetQuaKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoMatHang()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_NhapHangTheoNhaCungCap()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopChiPhiHoatDongKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopCongNoKhachHangToanTungCN()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopThuChiKhac()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang()
        {
            throw new System.NotImplementedException();
        }

        private async Task<ExpandoObject> GetFilterData_XuatNhapTonTongHop()
        {
            throw new System.NotImplementedException();
        }
    }
}