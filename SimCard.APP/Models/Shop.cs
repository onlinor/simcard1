using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("Shop")]
    public class Shop
    {   
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsTopShop { get; set; }
    }
}