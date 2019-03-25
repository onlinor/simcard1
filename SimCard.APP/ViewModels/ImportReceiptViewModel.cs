using System.Collections.Generic;

namespace SimCard.APP.ViewModels
{
    public class ImportReceiptViewModel
    {
        public int Id { get; set; }

        public string Ma { get; set; }

        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string Nhanvienlap { get; set; }

        public decimal Congnocu { get; set; }

        public string Nguoidaidien { get; set; }

        public int Sodienthoai { get; set; }

        public List<int> ProductIds { get; set; }

        public string Ghichu { get; set; }

        public decimal TongTien { get; set; }

        public decimal Tienthanhtoan { get; set; }

        public decimal Tienconlai { get; set; }

        public int ShopId { get; set;  }

        public int? SupplierId { get; set; } // Must import from supplier
    }
}