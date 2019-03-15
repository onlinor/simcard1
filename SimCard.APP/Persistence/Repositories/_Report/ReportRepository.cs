using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Controllers.Resources;
using SimCard.API.Persistence.Repositories;
using SimCard.API.Persistence.Repositories._Product;
using SimCard.API.Persistence.Repositories._Shop;
using SimCard.API.Persistence.Repositories._Warehouse;

namespace SimCard.API.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly ICashbookRepository _cashbookRepository;
        private readonly IBankbookRepository _bankbookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public ReportRepository(
            IProductRepository productRepository,
            ICashbookRepository cashbookRepository,
            IBankbookRepository bankbookRepository,
            ICustomerRepository customerRepository,
            IShopRepository shopRepository,
            IWarehouseRepository warehouseRepository)
        {
            _productRepository = productRepository;
            _cashbookRepository = cashbookRepository;
            _bankbookRepository = bankbookRepository;
            _customerRepository = customerRepository;
            _shopRepository = shopRepository;
            _warehouseRepository = warehouseRepository;
        }

        // Function to get report

        public async Task<List<ExpandoObject>> Report_ChiTietChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterResource filter)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            var products = await _productRepository.GetProducts();
            foreach (var product in products)
            {
                dynamic line = new List<ExpandoObject>();
                line.MatHang = product.Name;
                line.MaHang = product.Id;
                line.SoLuongToanCongTy = 0;
                var shops = await _shopRepository.Query(s => true).Include(s => s.Products).ToListAsync();
                foreach (var shop in shops)
                {
                    line[shop.Name] = shop.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                }
                result.Add(line);
            }
            return result;
        }

        public async Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_NhapHangTheoNhaCungCap(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterResource filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterResource filter)
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

        public async Task<List<ExpandoObject>> GetFilterData_ChiTietChiPhiHoatDongKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_ChiTietThuChiKhac()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_ChiTietXuatHangVaLoiNhuan()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_CongNoKhachHangToanCongTy()
        {
            throw new System.NotImplementedException();
        }

        public List<ExpandoObject> GetFilterData_HangTonKho()
        {
            // No filter data needed
            return null;
        }

        public async Task<List<ExpandoObject>> GetFilterData_KetQuaKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_NhapHangTheoMatHang()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_NhapHangTheoNhaCungCap()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopChiPhiHoatDongKinhDoanh()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopCongNoKhachHangToanTungCN()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopThuChiKhac()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ExpandoObject>> GetFilterData_XuatNhapTonTongHop()
        {
            throw new System.NotImplementedException();
        }
    }
}