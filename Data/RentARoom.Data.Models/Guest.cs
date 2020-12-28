namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Common.Models;

    public class Guest : BaseDeletableModel<int>
    {
        public string GuestId { get; set; }

        public string Name { get; set; }

        public int CardNumber { get; set; }

        public TypeGuest TypeGuest { get; set; }
    }
}
