using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimCard.APP.ViewModels
{
    public class ShopViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

        public ShopViewModel()
        {
            Products = new Collection<ProductViewModel>();
        }
    }
}