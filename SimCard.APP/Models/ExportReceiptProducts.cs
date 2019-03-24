using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ExportReceiptProducts : BaseEntity
    {
        [ForeignKey("ProductId")]
        public ImportReceipt Product { get; set; }

        public int ProductId { get; set; }

        public int ExportQuantity { get; set; }

        public int WarehouseQuantity { get; set; }

        public decimal ChietKhau { get; set; }
    }
}