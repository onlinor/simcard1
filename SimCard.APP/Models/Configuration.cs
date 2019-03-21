using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.Models
{
    public class Configuration : BaseEntity
    {
        [StringLength(255)]
        public string MaCH { get; set; }

        [StringLength(255)]
        public string TenCH { get; set; }

        [StringLength(255)]
        [Required]
        public string GiaTri { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        [StringLength(255)]
        [Required]
        public string ShopID { get; set; }
    }
}