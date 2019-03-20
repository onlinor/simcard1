using System;
using System.ComponentModel.DataAnnotations;

namespace SimCard.API.Models
{
    public class Event
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string LoaiSK { get; set; }

        public string MaSK { get; set; }

        [StringLength(255)]
        [Required]
        public string TenSK { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime TgBatDau { get; set; }

        public DateTime TgKetThuc { get; set; }

        [StringLength(255)]
        public string DoiTuong { get; set; }

        public bool EventStatus { get; set; }

        public bool IsNewEvent { get; set; }

        public bool IsCompleteEvent { get; set; }
    }
}