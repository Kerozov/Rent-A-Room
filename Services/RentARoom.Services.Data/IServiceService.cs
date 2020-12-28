namespace RentARoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IServiceService
    {
        IEnumerable<T> GetAllPopular<T>();
    }
}
