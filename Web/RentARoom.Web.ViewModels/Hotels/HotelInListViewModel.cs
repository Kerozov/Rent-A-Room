namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class HotelInListViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Hotel, HotelInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                 opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/hotels/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
