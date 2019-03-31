using System;

namespace SimCard.APP.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }
    }
}