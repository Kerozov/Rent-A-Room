namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Common.Models;

    public class Hotel : BaseDeletableModel<int>
    {
        public Hotel()
        {
            this.Services = new HashSet<HotelsServices>();
            this.Rooms = new HashSet<Room>();
            this.Images = new HashSet<Image>();
            this.Votes = new HashSet<Vote>();
        }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public virtual ICollection<HotelsServices> Services { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
