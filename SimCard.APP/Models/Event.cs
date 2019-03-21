using System;
using System.ComponentModel.DataAnnotations;

namespace SimCard.APP.Models
{
    public class Event : BaseEntity
    {
        [StringLength(255)]
        public string LoaiSK { get; set; }

        public string MaSK { get; set; }

        [StringLength(255)]
        [Required]
        public string TenSK { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime TgBatDau { get; set; }

        public DateTime TgKetThuc { get; set; }

        [StringLength(255)]
        public string DoiTuong { get; set; }

        public bool EventStatus { get; set; }

        public bool IsNewEvent { get; set; }

        public bool IsCompleteEvent { get; set; }
    }
}