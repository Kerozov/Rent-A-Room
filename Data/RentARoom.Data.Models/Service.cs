namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Hotels = new HashSet<HotelsServices>();
        }

        public string Name { get; set; }

        public ICollection<HotelsServices> Hotels { get; set; }
    }
}
