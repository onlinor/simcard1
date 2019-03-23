using SimCard.APP.Models;

namespace SimCard.APP.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public int Soluong { get; set; }

        public decimal Menhgia { get; set; }

        public decimal? Gianhap { get; set; }

        // public ProductType ProductType { get; set; }

        public int? ShopId { get; set; }

        public int? SupplierId { get; set; }

        public string ShopName { get; set; }

        public string SupplierName { get; set; }
    }
}