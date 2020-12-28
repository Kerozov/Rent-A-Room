namespace RentARoom.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RentARoom.Data.Common.Repositories;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;

    public class ServiceService : IServiceService
    {
        private readonly IDeletableEntityRepository<Service> serviceRepository;

        public ServiceService(IDeletableEntityRepository<Service> serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.serviceRepository.All()
                .Where(x => x.Hotels.Count >= 1)
                .To<T>().ToList();
        }
    }
}
