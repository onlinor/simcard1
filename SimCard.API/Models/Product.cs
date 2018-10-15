using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimCard.API.Models.RelationalClasses;

namespace SimCard.API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; } 

        [Required]
        [StringLength(255)]
        public string Name { get; set; }   
        public ICollection<ProductShop> ProductShops { get; set; }
    }
}