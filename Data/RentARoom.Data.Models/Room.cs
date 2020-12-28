namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using RentARoom.Data.Common.Models;

    public class Room : BaseDeletableModel<int>
    {
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public int Number { get; set; }

        public string RoomType { get; set; }

        public int Bed { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
