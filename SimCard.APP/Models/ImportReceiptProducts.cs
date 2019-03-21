using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ImportReceiptProducts : BaseEntity
    {
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ChietKhau { get; set; }
    }
}