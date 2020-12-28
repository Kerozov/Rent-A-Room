namespace RentARoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RentARoom.Services.Data;
    using RentARoom.Web.ViewModels.Vote;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVoteService votesService;

        public VotesController(IVoteService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.votesService.SetVoteAsync(input.HotelId, userId, input.Value);
            var averageVotes = this.votesService.GetAverageVotes(input.HotelId);
            return new PostVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
