namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class HotelServicesInputModel
    {
        [MinLength(4)]
        [MaxLength(20)]
        public string ServiceName { get; set; }
    }
}
