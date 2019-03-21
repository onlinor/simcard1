namespace SimCard.APP.Models
{
    public class ExportReceiptProducts : BaseEntity
    {
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ChietKhau { get; set; }
    }
}