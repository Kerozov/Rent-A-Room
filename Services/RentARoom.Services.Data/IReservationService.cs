namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RentARoom.Web.Views.Reservation;

    public interface IReservationService
    {
        public Task<IEnumerable<ReservationViewModel>> GetAllReservations(string guestId);

        public Task<int> AddReservation(DateTime checkIn, DateTime checkOut, string hotelName, int numberOfPeople, string guestId);
    }
}
