namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;

    public class HotelListViewModel : PagingViewModel
    {
        public IEnumerable<HotelInListViewModel> Hotels { get; set; }
    }
}
