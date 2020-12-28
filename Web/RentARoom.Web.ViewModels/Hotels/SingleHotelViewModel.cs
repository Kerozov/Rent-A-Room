namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;
    using RentARoom.Web.ViewModels.Administration.Dashboard;

    public class SingleHotelViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<ServicesViewModel> Services { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public double AverageVote { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Hotel, SingleHotelViewModel>()
                   .ForMember(x => x.AverageVote, opt =>
                    opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)))
                .ForMember(x => x.ImageUrl, opt =>
                 opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/hotels/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
