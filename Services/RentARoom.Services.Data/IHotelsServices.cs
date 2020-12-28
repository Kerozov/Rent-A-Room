namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RentARoom.Data.Common.Models;
    using RentARoom.Web.ViewModels.Hotels;

    public interface IHotelsServices
    {
        Task CreateAsync(Web.ViewModels.Hotels.AddHotelsInputViewModel input, string userId, string imagePath);

        IEnumerable<T> GetMostPopular<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditHotelInputViewModel input);

        IEnumerable<T> GetByServices<T>(IEnumerable<int> serviceIds);
    }
}
