using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }        
        public int Unit { get; set; }
    }
}