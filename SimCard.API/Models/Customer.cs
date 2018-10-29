using System;
using System.ComponentModel.DataAnnotations;

namespace SimCard.API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string tenCH { get; set; }

        [StringLength(255)]
        public string diachiCH { get; set; }

        [Required]
        [StringLength(255)]
        public string hoTen { get; set; }

        [StringLength(11)]
        public string sdt1 { get; set; }

        [StringLength(11)]
        public string sdt2 { get; set; }

        [StringLength(255)]
        public string maKH { get; set; }

        [Required]
        [StringLength(30)]
        public string matheTV { get; set; }

        [StringLength(255)]
        public string tenCongTy { get; set; }

        [StringLength(30)]
        public string masoThue { get; set; }

        [StringLength(255)]
        public string diachiHoaDon { get; set; }

        [StringLength(30)]
        public string nguonDen { get; set; }

        [StringLength(255)]
        public string ngGioiThieu { get; set; }
        
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string fb { get; set; }

        [StringLength(255)]
        public string zalo { get; set; }

        [Required]
        public DateTime ngayDen { get; set; }

        [Required]
        public DateTime ngaySinh { get; set; }

        [Required]
        public Boolean gioiTinh { get; set; }
    }
}