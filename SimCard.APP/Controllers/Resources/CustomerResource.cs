using System;

namespace SimCard.APP.Controllers.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string TenCH { get; set; }

        public string DiachiCH { get; set; }

        public string HoTen { get; set; }

        public string Sdt1 { get; set; }

        public string Sdt2 { get; set; }

        public string MaKH { get; set; }

        public string MatheTV { get; set; }

        public string TenCongTy { get; set; }

        public string MasoThue { get; set; }

        public string DiachiHoaDon { get; set; }

        public string NguonDen { get; set; }

        public string NgGioiThieu { get; set; }

        public string Email { get; set; }

        public string Fb { get; set; }

        public string Zalo { get; set; }

        public DateTime NgayDen { get; set; }

        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }
    }
}