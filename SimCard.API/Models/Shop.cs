using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimCard.API.Models.RelationalClasses;

namespace SimCard.API.Models
{
    [Table("Shop")]
    public class Shop
    {        
        public int ShopID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        //public ICollection<Product> Products { get; set; }
        public ICollection<ProductShop> ProductShops { get; set; }
    }
}