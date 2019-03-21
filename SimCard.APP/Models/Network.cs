using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.Models
{
    public class Network : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Ten { get; set; }

        public int Menhgia { get; set; }

        public float Chietkhaudauvao { get; set; }

        public float Chietkhaucaonhat { get; set; }

        public float Buocnhay { get; set; }

        public string Khungtien_1 { get; set; }

        public string Khungtien_2 { get; set; }

        public string Khungtien_3 { get; set; }

        public string Khungtien_4 { get; set; }

        public string Khungtien_5 { get; set; }

        public string Khungtien_6 { get; set; }

        public string Khungtien_7 { get; set; }
    }
}