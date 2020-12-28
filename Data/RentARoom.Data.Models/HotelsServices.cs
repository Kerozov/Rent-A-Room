namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HotelsServices
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
