﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }        

        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal BuyingPrice { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
    }
}