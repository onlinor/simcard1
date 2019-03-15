using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository reportRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("/api/Report/GetReport")]
        public async Task<List<ExpandoObject>> GetReport([FromBody]ReportFilterResource filter, int type)
        {
            switch (type)
            {
                case 1: return await Report_XuatNhapTonTongHop(filter);
                case 2: return await Report_HangTonKho(filter);
                case 3: return await Report_NhapHangTheoNhaCungCap(filter);
                case 4: return await Report_NhapHangTheoMatHang(filter);
                case 5: return await Report_ChiTietXuatHangVaLoiNhuan(filter);
                case 6: return await Report_TongHopXuatHangVaLoiNhuanTheoMatHang(filter);
                case 7: return await Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(filter);
                case 8: return await Report_CongNoKhachHangToanCongTy(filter);
                case 9: return await Report_TongHopCongNoKhachHangToanTungCN(filter);
                case 10: return await Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(filter);
                case 11: return await Report_ChiTietThuChiKhac(filter);
                case 12: return await Report_TongHopThuChiKhac(filter);
                case 13: return await Report_ChiTietChiPhiHoatDongKinhDoanh(filter);
                case 14: return await Report_TongHopChiPhiHoatDongKinhDoanh(filter);
                default: return await Report_KetQuaKinhDoanh(filter);
            }
        }

        [HttpPost("/api/Report/GetFilterData")]
        public async Task<List<ExpandoObject>> GetFilterData(int type)
        {
            switch (type)
            {
                case 1: return await GetFilterData_XuatNhapTonTongHop();
                case 2: return GetFilterData_HangTonKho();
                case 3: return await GetFilterData_NhapHangTheoNhaCungCap();
                case 4: return await GetFilterData_NhapHangTheoMatHang();
                case 5: return await GetFilterData_ChiTietXuatHangVaLoiNhuan();
                case 6: return await GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang();
                case 7: return await GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang();
                case 8: return await GetFilterData_CongNoKhachHangToanCongTy();
                case 9: return await GetFilterData_TongHopCongNoKhachHangToanTungCN();
                case 10: return await GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy();
                case 11: return await GetFilterData_ChiTietThuChiKhac();
                case 12: return await GetFilterData_TongHopThuChiKhac();
                case 13: return await GetFilterData_ChiTietChiPhiHoatDongKinhDoanh();
                case 14: return await GetFilterData_TongHopChiPhiHoatDongKinhDoanh();
                default: return await GetFilterData_KetQuaKinhDoanh();
            }
        }

        // Function to get report

        private async Task<List<ExpandoObject>> Report_XuatNhapTonTongHop(ReportFilterResource filter)
        {
            return await _reportRepository.Report_XuatNhapTonTongHop(filter);
        }

        private async Task<List<ExpandoObject>> Report_HangTonKho(ReportFilterResource filter) {
            return await _reportRepository.Report_HangTonKho(filter);
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoNhaCungCap(ReportFilterResource filter)
        {
            return await _reportRepository.Report_NhapHangTheoNhaCungCap(filter);;
        }

        private async Task<List<ExpandoObject>> Report_NhapHangTheoMatHang(ReportFilterResource filter)
        {
            return await _reportRepository.Report_NhapHangTheoMatHang(filter);;
        }

        private async Task<List<ExpandoObject>> Report_ChiTietXuatHangVaLoiNhuan(ReportFilterResource filter)
        {
            return await _reportRepository.Report_ChiTietXuatHangVaLoiNhuan(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangVaLoiNhuanTheoMatHang(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopXuatHangVaLoiNhuanTheoMatHang(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopXuatHangLoiNhuanCongNoTheoKhachHang(filter);;
        }

        private async Task<List<ExpandoObject>> Report_CongNoKhachHangToanCongTy(ReportFilterResource filter)
        {
            return await _reportRepository.Report_CongNoKhachHangToanCongTy(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopCongNoKhachHangToanTungCN(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopCongNoKhachHangToanTungCN(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopGiaoDichVaSoDuTKNHToanCongTy(filter);;
        }

        private async Task<List<ExpandoObject>> Report_ChiTietThuChiKhac(ReportFilterResource filter)
        {
            return await _reportRepository.Report_ChiTietThuChiKhac(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopThuChiKhac(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopThuChiKhac(filter);;
        }

        private async Task<List<ExpandoObject>> Report_ChiTietChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            return await _reportRepository.Report_ChiTietChiPhiHoatDongKinhDoanh(filter);;
        }

        private async Task<List<ExpandoObject>> Report_TongHopChiPhiHoatDongKinhDoanh(ReportFilterResource filter)
        {
            return await _reportRepository.Report_TongHopChiPhiHoatDongKinhDoanh(filter);;
        }

        private async Task<List<ExpandoObject>> Report_KetQuaKinhDoanh(ReportFilterResource filter)
        {
            return await _reportRepository.Report_KetQuaKinhDoanh(filter);;
        }

        // Function to get filter data

        private async Task<List<ExpandoObject>> GetFilterData_XuatNhapTonTongHop()
        {
            return await _reportRepository.GetFilterData_XuatNhapTonTongHop();
        }

        private List<ExpandoObject> GetFilterData_HangTonKho() {
            return _reportRepository.GetFilterData_HangTonKho();
        }

        private async Task<List<ExpandoObject>> GetFilterData_NhapHangTheoNhaCungCap()
        {
            return await _reportRepository.GetFilterData_NhapHangTheoNhaCungCap();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_NhapHangTheoMatHang()
        {
            return await _reportRepository.GetFilterData_NhapHangTheoMatHang();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_ChiTietXuatHangVaLoiNhuan()
        {
            return await _reportRepository.GetFilterData_ChiTietXuatHangVaLoiNhuan();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang()
        {
            return await _reportRepository.GetFilterData_TongHopXuatHangVaLoiNhuanTheoMatHang();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang()
        {
            return await _reportRepository.GetFilterData_TongHopXuatHangLoiNhuanCongNoTheoKhachHang();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_CongNoKhachHangToanCongTy()
        {
            return await _reportRepository.GetFilterData_CongNoKhachHangToanCongTy();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopCongNoKhachHangToanTungCN()
        {
            return await _reportRepository.GetFilterData_TongHopCongNoKhachHangToanTungCN();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy()
        {
            return await _reportRepository.GetFilterData_TongHopGiaoDichVaSoDuTKNHToanCongTy();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_ChiTietThuChiKhac()
        {
            return await _reportRepository.GetFilterData_ChiTietThuChiKhac();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopThuChiKhac()
        {
            return await _reportRepository.GetFilterData_TongHopThuChiKhac();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_ChiTietChiPhiHoatDongKinhDoanh()
        {
            return await _reportRepository.GetFilterData_ChiTietChiPhiHoatDongKinhDoanh();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_TongHopChiPhiHoatDongKinhDoanh()
        {
            return await _reportRepository.GetFilterData_TongHopChiPhiHoatDongKinhDoanh();;
        }

        private async Task<List<ExpandoObject>> GetFilterData_KetQuaKinhDoanh()
        {
            return await _reportRepository.GetFilterData_KetQuaKinhDoanh();;
        }
    }
}