using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SimCard.APP.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }

        // Fix self referencing loop detected for property 'supplier' with type 'SimCard.APP.Models.Supplier'
        [JsonIgnore] 
        [IgnoreDataMember]
        public List<Product> Products { get; set; }
    }
}