using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("Phieunhap")]
    public class Phieunhap
    {
        public string Prefixid { get; set; }
        public int Suffixid { get; set; }
        public DateTime Ngaylap { get; set; }        
        public string Nhanvienlap { get; set; }
        public string Tennhacungcap { get; set; }
        public decimal Congnocu { get; set; }
        public string Nguoidaidien { get; set; }
        public int Sodienthoai { get; set; }
        public Product[] Dssanpham {get; set;}
        public string Ghichu { get; set; }
        public decimal Tienthanhtoan { get; set; }
        public decimal Tienconlai { get; set; }
    }
}