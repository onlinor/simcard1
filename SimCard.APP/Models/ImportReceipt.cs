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

        [Column(TypeName = "decimal(18,2)")]
        public decimal Congnocu { get; set; }

        public string Nguoidaidien { get; set; }

        public int Sodienthoai { get; set; }

        public List<ImportReceiptProducts> Products { get; set; }

        public string Ghichu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tienthanhtoan { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tienconlai { get; set; }

        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        // Import from a parent shop: for child shop only
        public int? ImportFromShopId { get; set; }

        // Import from a supplier: for parent shop only
        public int? ImmportFromSupplierId { get; set; }
    }
}