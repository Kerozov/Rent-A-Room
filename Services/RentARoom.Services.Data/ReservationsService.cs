namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RentARoom.Data.Common.Repositories;
    using RentARoom.Data.Models;
    using RentARoom.Web.Views.Reservation;

    public class ReservationsService : IReservationService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationRepo;
        private readonly IDeletableEntityRepository<Room> roomRepository;

        public ReservationsService(
            IDeletableEntityRepository<Reservation> reservationRepo,
            IDeletableEntityRepository<Room> roomRepository)
        {
            this.reservationRepo = reservationRepo;
            this.roomRepository = roomRepository;
        }

        public async Task<int> AddReservation(DateTime checkIn, DateTime checkOut, string hotelName, int numberOfPeople, string guestId)
        {
            var room = this.roomRepository.All().FirstOrDefault(x => x.Hotel.Name == hotelName);
            if (room == null)
            {
                return -1;
            }

            var reservation = new Reservation
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestId = guestId,
                RoomId = room.Number,
            };

            this.roomRepository.All().FirstOrDefault(x => x.Hotel.Name == hotelName).Bed -= numberOfPeople;
            this.roomRepository.All().FirstOrDefault(x => x.Hotel.Name == hotelName).Capacity -= numberOfPeople;

            await this.roomRepository.SaveChangesAsync();
            await this.reservationRepo.AddAsync(reservation);
            await this.reservationRepo.SaveChangesAsync();
            return 0;
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllReservations(string guestId)
        {
            var reservations = await this.reservationRepo.All()
                    .Where(x => x.GuestId == guestId)
                    .Select(x => new ReservationViewModel
                    {
                        ChechIn = x.CheckIn,
                        CheckOut = x.CheckOut,
                    })
                    .ToListAsync();
            return reservations;
        }
    }
}
