namespace RentARoom.Web.ViewModels.SearchHotels
{
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class ServiceNameViewModel : IMapFrom<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
