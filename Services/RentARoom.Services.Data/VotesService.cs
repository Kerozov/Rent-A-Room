namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RentARoom.Data.Common.Repositories;
    using RentARoom.Data.Models;

    public class VotesService : IVoteService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int hotelId)
        {
            return this.votesRepository.All()
               .Where(x => x.HotelID == hotelId)
               .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int hotelId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(h => h.HotelID == hotelId && h.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    HotelID = hotelId,
                    UserId = userId,
                };
                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
