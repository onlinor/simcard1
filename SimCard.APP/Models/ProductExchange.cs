using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class ProductExchange : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Ten { get; set; }

        public string Ma { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Menhgia { get; set; }

        public string Loai { get; set; }
    }
}
