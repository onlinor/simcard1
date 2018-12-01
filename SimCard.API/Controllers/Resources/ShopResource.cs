using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimCard.API.Controllers.Resources
{
    public class ShopResource
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductResource> Products { get; set; }

        public ShopResource()
        {
            Products = new Collection<ProductResource>();
        }
    }
}