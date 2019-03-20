using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("Export Receipt")]
    public class ExportReceipt
    {
        [Key]
        public int ID { get; set; }
        public string Prefixid { get; set; }
        public int Suffixid { get; set; }
        public DateTime CreateDate { get; set; }        
        public string CreateByStaff { get; set; }
        public string SupplierName { get; set; }
        public decimal OldDebt { get; set; }
        public string RepresentativePerson { get; set; }
        public int PhoneNumber { get; set; }
        public string Note { get; set; }
        public decimal MoneyPaid { get; set; }
        public decimal Debt { get; set; }
        public string Shopid { get; set; }
    }
}