using System.Collections.Generic;

namespace SimCard.APP.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}