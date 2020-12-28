namespace RentARoom.Web.ViewModels.Vote
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class PostVoteInputModel
    {
        public int HotelId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
