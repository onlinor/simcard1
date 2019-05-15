using System;

namespace SimCard.APP.ViewModels
{
    public class DebtbookViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string TenKhachHang { get; set; }

        public string MaKhachHang { get; set; }

        public string SoPhieu { get; set; }

        public string NoiDungPhieu { get; set; }

        public int NoKhach { get; set; }

        public int KhachNo { get; set; }

        public int CongDon { get; set; }
    }
}