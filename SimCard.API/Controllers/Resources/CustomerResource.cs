using System;

namespace SimCard.API.Controllers.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public Boolean Gender { get; set; }
        public string Email { get; set; }
    }
}