namespace RentARoom.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RentARoom.Web.ViewModels.Home;

    public class IndexViewModel
    {
        public IEnumerable<IndexPageHotelViewModel> Hotels { get; set; }
    }
}
