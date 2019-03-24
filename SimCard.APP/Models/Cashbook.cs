using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class Cashbook : BaseEntity
    {
        [StringLength(255)]
        public string TenKhachHang { get; set; }

        [StringLength(255)]
        public string MaKhachHang { get; set; }

        [StringLength(255)]
        public string MaPhieu { get; set; }

        [StringLength(255)]
        public string NoiDungPhieu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoTienThu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoTienChi { get; set; }

        public int CongDon { get; set; }

        [StringLength(255)]
        public string DonViNop { get; set; }

        [StringLength(255)]
        public string DonViNhan { get; set; }

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

        public string LoaiNganHang { get; set; }
    }
}