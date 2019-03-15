using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using SimCard.API.Controllers.Resources;

namespace SimCard.API.Persistence.Repositories
{
    public interface IReportRepository
    {
        // Function to get report
        
        Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_NhapHangTheoNhaCungCap(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_ChiTietChiPhiHoatDongKinhDoanh(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterResource filter);

        Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterResource filter);

        // Functions to get filter data

        Task<List<ExpandoObject>> GetFilterData_ChiTietChiPhiHoatDongKinhDoanh();

        Task<List<ExpandoObject>> GetFilterData_ChiTietThuChiKhac();

        Task<List<ExpandoObject>> GetFilterData_ChiTietXuatHangVaLoiNhuan();

        Task<List<ExpandoObject>> GetFilterData_CongNoKhachHangToanCongTy();

        List<ExpandoObject> GetFilterData_HangTonKho();

        Task<List<ExpandoObject>> GetFilterData_KetQuaKinhDoanh();

        Task<List<ExpandoObject>> GetFilterData_NhapHangTheoMatHang();

        Task<List<ExpandoObject>> GetFilterData_NhapHangTheoNhaCungCap();

        Task<List<ExpandoObject>> GetFilterData_TongHopChiPhiHoatDongKinhDoanh();

        Task<List<ExpandoObject>> GetFilterData_TongHopCongNoKhachHangToanTungCN();

        Task<List<ExpandoObject>> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy();

        Task<List<ExpandoObject>> GetFilterData_TongHopThuChiKhac();

        Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang();

        Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang();

        Task<List<ExpandoObject>> GetFilterData_XuatNhapTonTongHop();
    }
}