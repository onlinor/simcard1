using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("ProductShop")]
    public class ProductShop
    {
        public string ProductID { get; set; }
        public string ShopID { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        //Relationships
        public Product Product { get; set; } 
        public Shop Shop { get; set; }
    }
}