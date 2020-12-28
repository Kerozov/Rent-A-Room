namespace RentARoom.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class IndexPageHotelViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Hotel, IndexPageHotelViewModel>()
          .ForMember(x => x.ImageUrl, opt =>
           opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/hotels/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
