namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using RentARoom.Data.Models;
    using RentARoom.Web.ViewModels.Administration.Dashboard;
    using RentARoom.Web.ViewModels.Hotels;

    public class AddHotelsInputViewModel : BaseHotelsInputModel
    {
        public IEnumerable<IFormFile> Image { get; set; }

        ////public byte[] Images { get; set; }
        [Range(0, 5)]
        [Display(Name = "How many stars is your hotel?")]
        public int Stars { get; set; }

        [Range(1, 10000)]
        [Display(Name = "What is the total number of rooms in your hotel?")]
        public int CountRooms { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "How many bad have in your hotel?")]
        public int Bed { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }

        public IEnumerable<HotelServicesInputModel> Services { get; set; }
    }
}
