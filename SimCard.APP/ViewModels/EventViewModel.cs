using System;

namespace SimCard.APP.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string LoaiSK { get; set; }

        public string MaSK { get; set; }

        public string TenSK { get; set; }

        public string NoiDung { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime TgBatDau { get; set; }

        public DateTime TgKetThuc { get; set; }

        public string DoiTuong { get; set; }

        public Boolean EventStatus { get; set; }

        public Boolean IsNewEvent { get; set; }

        public Boolean IsCompleteEvent { get; set; }
    }
}