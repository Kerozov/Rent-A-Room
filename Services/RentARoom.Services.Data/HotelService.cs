namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RentARoom.Data.Common.Models;
    using RentARoom.Data.Common.Repositories;
    using RentARoom.Data.Models;
    using RentARoom.Services.Mapping;
    using RentARoom.Web.ViewModels.Hotels;

    public class HotelService : IHotelsServices
    {
        private readonly string[] allowedExtension = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Hotel> hotelsRepository;
        private readonly IDeletableEntityRepository<Service> serviceRepository;
        private readonly IDeletableEntityRepository<Room> roomRepository;

        public HotelService(
                            IDeletableEntityRepository<Hotel> hotelsRepository,
                            IDeletableEntityRepository<Service> serviceRepository,
                            IDeletableEntityRepository<Room> roomRepository)
        {
            this.hotelsRepository = hotelsRepository;
            this.serviceRepository = serviceRepository;
            this.roomRepository = roomRepository;
        }

        public async Task CreateAsync(AddHotelsInputViewModel input, string userId, string imagePath)
        {
            var hotel = new Hotel()
            {
                Address = input.Address,
                Town = input.Town,
                Stars = input.Stars,
                Name = input.Name,
                CategoryId = input.CategoryId,
                AddedByUserId = userId,
                Price = input.Price,
                Description = input.Description,
            };
            for (int i = 0; i < input.CountRooms; i++)
            {
                var room = new Room
                {
                    Bed = input.Bed,
                    Capacity = input.Capacity,
                };
                hotel.Rooms.Add(room);
            }

            if (input.Services != null)
            {
                foreach (var service in input.Services)
                {
                    var currService = this.serviceRepository.All().FirstOrDefault(x => x.Name == service.ServiceName);
                    if (currService == null)
                    {
                        currService = new Service
                        {
                            Name = service.ServiceName,
                        };
                    }

                    hotel.Services.Add(new HotelsServices { Service = currService });
                }
            }

            //// / wwwroot / images / hotel /{ id}.{ ext}
            Directory.CreateDirectory($"{imagePath}/hotels/");
            foreach (var image in input.Image)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtension.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                hotel.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/hotels/{dbImage.Id}.{extension}";
                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.hotelsRepository.AddAsync(hotel);
            await this.hotelsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetMostPopular<T>(int page, int itemsPerPage = 12)
        {
            var hotels = this.hotelsRepository.AllAsNoTracking()
                  .OrderByDescending(x => x.Votes.Average(x => x.Value))
                  .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                  .To<T>()
                  .ToList();
            return hotels;
        }

        public T GetById<T>(int id)
        {
            var hotel = this.hotelsRepository.AllAsNoTracking().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return hotel;
        }

        public IEnumerable<T> GetByServices<T>(IEnumerable<int> serviceIds)
        {
            var query = this.hotelsRepository.All().AsQueryable();
            foreach (var serviceId in serviceIds)
            {
                query = query.Where(x => x.Services.Any(i => i.ServiceId == serviceId));
            }

            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.hotelsRepository.All().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.hotelsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>().ToList();
        }

        public async Task UpdateAsync(int id, EditHotelInputViewModel input)
        {
            var hotels = this.hotelsRepository.All().FirstOrDefault(x => x.Id == id);
            hotels.Name = input.Name;
            hotels.Town = input.Town;
            hotels.Address = input.Address;
            hotels.Price = input.Price;
            hotels.Description = input.Description;
            hotels.CategoryId = input.CategoryId;
            await this.hotelsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = this.hotelsRepository.All().FirstOrDefault(x => x.Id == id);
            this.hotelsRepository.Delete(hotel);
            await this.hotelsRepository.SaveChangesAsync();
        }
    }
}
