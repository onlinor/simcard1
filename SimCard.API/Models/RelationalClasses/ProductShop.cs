namespace SimCard.API.Models.RelationalClasses
{
    public class ProductShop
    {
        public int ShopID { get; set; }
        public Shop Shop { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}