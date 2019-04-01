using System.Collections.Generic;

namespace SimCard.APP.ViewModels
{

    public class ExportReceiptViewModel
    {
        public string Ma { get; set; }

        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string NhanVienLap { get; set; }

        public string NguoiDaiDien { get; set; }

        public string SoDienThoai { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public string GhiChu { get; set; }

        public decimal TienThanhToan { get; set; }

        public decimal TienConLai { get; set; }

        public int ShopId { get; set; }
        public int? ExportToShopId { get; set; }

        public int? ExportToCustomerId { get; set; }
    }
}
