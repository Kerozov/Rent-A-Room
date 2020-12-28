using RentARoom.Data.Models;
using RentARoom.Services.Mapping;

namespace RentARoom.Web.ViewModels.SearchHotels
{
    public class ServiceNameViewModel : IMapFrom<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}