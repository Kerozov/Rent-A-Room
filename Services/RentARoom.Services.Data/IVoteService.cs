namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task SetVoteAsync(int hotelId, string userId, byte value);

        double GetAverageVotes(int hotelId);
    }
}
