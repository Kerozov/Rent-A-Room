namespace RentARoom.Web.ViewModels.SearchHotels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Web.ViewModels.Hotels;

   public class ListViewModel
    {
        public IEnumerable<HotelInListViewModel> Hotels { get; set; }
    }
}
