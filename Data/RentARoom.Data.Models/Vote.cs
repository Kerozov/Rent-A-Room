namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int HotelID { get; set; }

        public virtual Hotel Hotel { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
