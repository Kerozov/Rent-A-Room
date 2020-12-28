namespace RentARoom.Web.ViewModels.Reservation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class ReservationInputModel : IMapFrom<Room>
    {
        [BindProperty]
        [Required]
        public DateTime ChechIn { get; set; }

        [BindProperty]
        [Required]
        public DateTime CheckOut { get; set; }

        [BindProperty]
        [Required]
        public string HotelName { get; set; }

        [BindProperty]
        [Required]
        public int NumberOfPeople { get; set; }
    }
}
