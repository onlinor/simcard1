﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCard.APP.Models
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Director { get; set; }

        public List<Shop> Childrens { get; set; }

        [ForeignKey("ShopId")]
        public Shop Parent { get; set; }

        public int? ParentId { get; set; }

        public List<Product> Products { get; set; }

        public List<ImportReceipt> ImportReceipts { get; set; }

        public List<ExportReceipt> ExportReceipts { get; set; }

        public List<Cashbook> Cashbooks { get; set; }
    }
}