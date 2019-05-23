using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.Models
{
    public class Network : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Ten { get; set; }

        public string Ma { get; set; }

        public int MenhGia { get; set; }

        public float ChietKhauDauVao { get; set; }

        public float ChietKhauCaoNhat { get; set; }

        public float BuocNhay { get; set; }

        public float KhungTien_1 { get; set; }

        public float KhungTien_2 { get; set; }

        public float KhungTien_3 { get; set; }

        public float KhungTien_4 { get; set; }

        public float KhungTien_5 { get; set; }

        public float KhungTien_6 { get; set; }

        public float KhungTien_7 { get; set; }
    }
}