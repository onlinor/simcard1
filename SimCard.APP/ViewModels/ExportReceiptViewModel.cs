namespace SimCard.APP.ViewModels
{
    public class ExportReceiptViewModel
    {
        public string Ma { get; set; }
        public string Prefix { get; set; }

        public int Suffix { get; set; }

        public string Nhanvienlap { get; set; }

        public decimal OldDebt { get; set; }

        public string RepresentativePerson { get; set; }

        public int PhoneNumber { get; set; }

        public string Note { get; set; }

        public decimal MoneyPaid { get; set; }

        public decimal Debt { get; set; }

        public int ShopId { get; set; }

        public int? ExportToShopId { get; set; }

        public int? ExportToCustomerId { get; set; }
    }
}
