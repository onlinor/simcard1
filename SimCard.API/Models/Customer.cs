using System;
using System.ComponentModel.DataAnnotations;

namespace SimCard.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string tenCH { get; set; }
        public string diachiCH { get; set; }
        public string hoTen { get; set; }
        public string sdt1 { get; set; }
        public string sdt2 { get; set; }
        public string maKH { get; set; }
        public string matheTV { get; set; }
        public string tenCongTy { get; set; }
        public string masoThue { get; set; }
        public string diachiHoaDon { get; set; }
        public string nguonDen { get; set; }
        public string ngGioiThieu { get; set; }
        public string email { get; set; }
        public string fb { get; set; }
        public string zalo { get; set; }
        public DateTime ngayDen { get; set; }
        public DateTime ngaySinh { get; set; }
        public Boolean gioiTinh { get; set; }
    }
}