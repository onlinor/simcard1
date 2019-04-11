using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ExportReceiptProducts : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ExportReceiptId { get; set; }

        [ForeignKey("ExportReceiptId")]
        public ExportReceipt ExportReceipt { get; set; }

        public int ExportQuantity { get; set; }

        public int NewWarehouseQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ChietKhau { get; set; }
    }
}