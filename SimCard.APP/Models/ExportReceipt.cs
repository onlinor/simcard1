using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ExportReceipt : BaseEntity
    {
        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string CreateByStaff { get; set; }

        public decimal OldDebt { get; set; }

        public string RepresentativePerson { get; set; }

        public int PhoneNumber { get; set; }

        public string Note { get; set; }

        public decimal MoneyPaid { get; set; }

        public decimal Debt { get; set; }

        public List<ExportReceiptProducts> Products { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public int ShopId { get; set; }

        // Export to shop
        [ForeignKey("ExportToShopId")]
        public Customer ExportToShop { get; set; }

        public int? ExportToShopId { get; set; }

        // Export to Customer
        [ForeignKey("ExportToCustomerId")]
        public Customer ExportToCustomer { get; set; }

        public int? ExportToCustomerId { get; set; }
    }
}