namespace SimCard.API.Controllers.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Buyingprice { get; set; }
        public int shopid { get; set; }
    }
}