namespace RentARoom.Web.ViewModels.Reservation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentARoom.Web.Views.Reservation;

    public class AllReservationsViewModel
    {
        public List<ReservationViewModel> Reservations { get; set; }
    }
}
