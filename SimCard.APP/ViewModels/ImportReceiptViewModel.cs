using System;
using System.Collections.Generic;

namespace SimCard.APP.ViewModels
{
    public class ImportReceiptViewModel
    {
        public string Ma { get; set; }

        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string NhanVienLap { get; set; }

        public decimal CongNoCu { get; set; }

        public string NguoiDaiDien { get; set; }

        public int SoDienThoai { get; set; }

        public List<ProductViewModel> Products { get; set; }
        
        public string GhiChu { get; set; }

        public decimal TongTien { get; set; }

        public decimal TienThanhToan { get; set; }

        public decimal TienConLai { get; set; }

        public int SupplierId { get; set; } // Must import from supplier

        public int ShopId { get; set;  }
    }
}