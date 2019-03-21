using System;

namespace SimCard.APP.ViewModels
{
    public class ConfigurationViewModel
    {
        public int Id { get; set; }

        public string MaCH { get; set; }

        public string TenCH { get; set; }

        public string GiaTri { get; set; }

        public DateTime DateCreated { get; set;}

        public string GhiChu { get; set; }

        public int ShopId { get; set; }
    }
}