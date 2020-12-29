namespace RentARoom.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class ImagesHotelViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Image> Images { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Hotel, ImagesHotelViewModel>()
        //        .ForMember(x => x.ImageUrl, opt =>
        //         opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/hotels/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        //}
    }
}
