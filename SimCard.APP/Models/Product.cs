using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Ten { get; set; }

        public string Ma { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Menhgia { get; set; }

        public int Soluong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
       // Gianhap of main shop
        public decimal? DonGia { get; set; }

        // Shop will have buying price but supplier does not
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
        
        public int? ShopId { get; set; }

        public string Loai { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public int? SupplierId { get; set; }
    }
}