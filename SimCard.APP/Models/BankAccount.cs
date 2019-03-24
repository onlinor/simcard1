using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class BankAccount : BaseEntity
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
    }
}
