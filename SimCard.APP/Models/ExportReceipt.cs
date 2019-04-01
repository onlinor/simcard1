using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ExportReceipt : BaseEntity
    {
        public string Ma { get; set; }

        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string Nhanvienlap { get; set; }

        public string RepresentativePerson { get; set; }

        public string PhoneNumber { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MoneyPaid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debt { get; set; }

        public List<ExportReceiptProducts> Products { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public int ShopId { get; set; }

        // Export to shop
        public int? ExportToShopId { get; set; }

        // Export to Customer
        public int? ExportToCustomerId { get; set; }
    }
}