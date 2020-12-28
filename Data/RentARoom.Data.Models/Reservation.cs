namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using RentARoom.Data.Common.Models;

    public class Reservation : BaseDeletableModel<int>
    {
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
