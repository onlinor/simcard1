using System.ComponentModel.DataAnnotations;
using System;

namespace SimCard.API.Models
{
    public class Configuration
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string MaCH { get; set; }

        [StringLength(255)]
        public string TenCH { get; set; }

        [StringLength(255)]
        [Required]
        public string GiaTri { get; set; }

        public DateTime NgayTao { get; set;}

        [StringLength(255)]
        public string GhiChu { get; set; }

        [StringLength(255)]
        [Required]
        public string ShopID { get; set; }
    }
}