using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ImportReceipt : BaseEntity
    {
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

        // Import from another shop: for branches only
        [ForeignKey("ImportFromShopId")]
        public Shop ImportFromShop { get; set; }

        public int? ImportFromShopId { get; set; }

        // Import from a supplier: for parent shop only
        [ForeignKey("ImportFromSupplierId")]
        public Supplier ImportFromSupplier { get; set; }

        public int? ImportFromSupplierId { get; set; }
    }
}