using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ImportReceiptProducts : BaseEntity
    {
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int ImportQuantity { get; set; }

        public int NewWarehouseQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ChietKhau { get; set; }
    }
}