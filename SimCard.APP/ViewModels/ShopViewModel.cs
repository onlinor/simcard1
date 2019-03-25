using System.Collections.Generic;

namespace SimCard.APP.ViewModels
{
    public class ShopViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public ShopViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}