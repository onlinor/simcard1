using System;
using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.Models
{
    public class Customer : BaseEntity
    {
        [StringLength(255)]
        public string TenCH { get; set; }

        [StringLength(255)]
        public string DiachiCH { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [StringLength(11)]
        public string Sdt1 { get; set; }

        [StringLength(11)]
        public string Sdt2 { get; set; }

        [StringLength(255)]
        public string MaKH { get; set; }

        [StringLength(30)]
        public string MatheTV { get; set; }

        [StringLength(255)]
        public string TenCongTy { get; set; }

        [StringLength(30)]
        public string MasoThue { get; set; }

        [StringLength(255)]
        public string DiachiHoaDon { get; set; }

        [StringLength(30)]
        public string NguonDen { get; set; }

        [StringLength(255)]
        public string NgGioiThieu { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Fb { get; set; }

        [StringLength(255)]
        public string Zalo { get; set; }

        public DateTime NgayDen { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public bool GioiTinh { get; set; }
    }
}