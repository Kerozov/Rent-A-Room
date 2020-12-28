namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class EditHotelInputViewModel : BaseHotelsInputModel, IMapFrom<Hotel>
    {
        public int Id { get; set; }
    }
}
