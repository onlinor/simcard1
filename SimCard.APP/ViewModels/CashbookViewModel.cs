using System;

namespace SimCard.APP.ViewModels
{
    public class CashbookViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string TenKhachHang { get; set; }

        public string MaKhachHang { get; set; }

        public string MaPhieu { get; set; }

        public string NoiDungPhieu { get; set; }

        public int SoTienThu { get; set; }

        public int SoTienChi { get; set; }

        public int CongDon { get; set; }

        public string DonViNop { get; set; }

        public string DonViNhan { get; set; }

        public string HinhThucNop { get; set; }

        public string HinhThucChi { get; set; }

        public string NguoiChi { get; set; }

        public string NguoiThu { get; set; }

        public string GhiChu { get; set; }

        public string LoaiNganHang { get; set; }
    }
}