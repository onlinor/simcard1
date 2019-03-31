using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Ma { get; set; }

        [Required]
        public string Ten { get; set; }

        [Required]
        public int Soluong { get; set; }

        [Required]
        public decimal Menhgia { get; set; }

        public decimal? DonGia { get; set; }

        // public ProductType ProductType { get; set; }

        public int? ShopId { get; set; }

        public int? SupplierId { get; set; }

        public string ShopName { get; set; }

        public string SupplierName { get; set; }
    }
}