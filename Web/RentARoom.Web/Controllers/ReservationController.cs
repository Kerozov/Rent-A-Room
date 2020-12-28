namespace RentARoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RentARoom.Data.Common.Repositories;
    using RentARoom.Data.Models;
    using RentARoom.Services.Data;
    using RentARoom.Web.ViewModels.Reservation;
    using RentARoom.Web.Views.Reservation;

    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        public ReservationController(
            IReservationService reservationService,
            IDeletableEntityRepository<Hotel> hotelRepository)
        {
            this.reservationService = reservationService;
            this.hotelRepository = hotelRepository;
        }

        public IActionResult New(int id)
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> New(ReservationInputModel input, int id)
        {
            var hotelName = this.hotelRepository.All().FirstOrDefault(x => x.Id == id).Name;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await this.reservationService.AddReservation(input.ChechIn, input.CheckOut, hotelName, input.NumberOfPeople, userId);
            if (result >= 0)
            {
                return this.RedirectToAction("ThankYou");
            }

            return this.NotFound();
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
