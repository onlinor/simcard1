using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class Debtbook : BaseEntity
    {
        public int STT { get; set; }

        [StringLength(255)]
        public string TenKhachHang { get; set; }

        [StringLength(255)]
        public string MaKhachHang { get; set; }

        [StringLength(255)]
        public string SoPhieu { get; set; }

        [StringLength(255)]
        public string NoiDungPhieu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NoKhach { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal KhachNo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CongDon { get; set; }
    }
}