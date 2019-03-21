using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }        

        public int Quantity { get; set; }

        public int Unit { get; set; }

        public decimal BuyingPrice { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public int? ShopId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }
    }
}