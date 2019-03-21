using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ImportReceipt : BaseEntity
    {
        public string Ma { get; set; }

        public string Prefix { get; set; }
        
        public int Suffix { get; set; }

        public string Nhanvienlap { get; set; }

        public decimal Congnocu { get; set; }

        public string Nguoidaidien { get; set; }

        public int Sodienthoai { get; set; }

        public List<ImportReceiptProducts> Products { get; set; }

        public string Ghichu { get; set; }

        public decimal Tienthanhtoan { get; set; }

        public decimal Tienconlai { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public int ShopId { get; set; }

        // Import from a supplier: for parent shop only
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public int? SupplierId { get; set; }
    }
}