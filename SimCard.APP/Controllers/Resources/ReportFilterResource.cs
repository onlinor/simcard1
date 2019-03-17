using System;

namespace SimCard.API.Controllers.Resources
{
    public class ReportFilterResource
    {
        public int Shop { get; set; } 

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int Product { get; set; }

        public int Warehouse { get; set; }

        public int Customer { get; set; }

        public int BankAccount { get; set; }
    }
}