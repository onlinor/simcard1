using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public int Soluong { get; set; }

        public decimal Menhgia { get; set; }

        public decimal? DonGia { get; set; }

        public int? ShopId { get; set; }

        public int? SupplierId { get; set; }
        public string ShopName { get; set; }

        public string Loai { get; set; }

        public string SupplierName { get; set; }

        public int SoLuongNhap { get; set; }

        public int SoLuongXuat { get; set; }
    }
}