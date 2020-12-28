namespace RentARoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
