using System.ComponentModel.DataAnnotations;
using System;

namespace SimCard.API.Models
{
    public class Bankbook {
        public int Id { get; set; }

        public DateTime NgayLap { get; set; }

        [StringLength(255)]
        public string TenKhachHang { get; set; }

        [StringLength(255)]
        public string MaKhachHang { get; set; }

        [StringLength(255)]
        public string MaPhieu { get; set; }

        [StringLength(255)]
        public string NoiDungPhieu { get; set; }

        public int SoTienThu { get; set; }
        public int SoTienChi { get; set; }
        public int CongDon { get; set; }

        [StringLength(255)]
        public string DonViNop { get; set; }

        [StringLength(255)]
        public string DonViNhan { get; set; }

        [StringLength(255)]
        public string LiDoNop { get; set; }

        [StringLength(255)]
        public string LiDoChi { get; set; }

        [StringLength(255)]
        public string HinhThucNop { get; set; }

        [StringLength(255)]
        public string HinhThucChi { get; set; }

        [StringLength(255)]
        public string NguoiChi { get; set; }

        [StringLength(255)]
        public string NguoiThu { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }
    }
}