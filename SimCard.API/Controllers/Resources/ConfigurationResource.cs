using System;

namespace SimCard.API.Controllers.Resources
{
    public class ConfigurationResource
    {
        public int Id { get; set; }
        public string MaCH { get; set; }
        public string TenCH { get; set; }
        public string GiaTri { get; set; }
        public DateTime NgayTao { get; set;}
        public string GhiChu { get; set; }
        public string ShopID { get; set; }
    }
}