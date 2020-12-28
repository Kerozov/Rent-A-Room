namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Transactions;

    using RentARoom.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
        ////The content of the image is in the file system
    }
}
