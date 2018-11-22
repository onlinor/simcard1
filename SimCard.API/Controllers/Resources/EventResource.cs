using System;

namespace SimCard.API.Controllers.Resources
{
    public class EventResource
    {
        public int Id { get; set; }

        public string LoaiSK { get; set; }

        public string MaSK { get; set; }

        public string TenSK { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime TgBatDau { get; set; }

        public DateTime TgKetThuc { get; set; }

        public string DoiTuong { get; set; }

        public Boolean EventStatus { get; set; }

        public Boolean isNewEvent { get; set; }

        public Boolean isCompleteEvent { get; set; }
    }
}