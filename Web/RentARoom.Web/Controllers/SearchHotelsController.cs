namespace RentARoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RentARoom.Services.Data;
    using RentARoom.Web.ViewModels.Hotels;
    using RentARoom.Web.ViewModels.SearchHotels;

    public class SearchHotelsController : BaseController
    {
        private readonly IHotelsServices hotelService;
        private readonly IServiceService serviceService;

        public SearchHotelsController(
            IHotelsServices hotelService,
            IServiceService serviceService)
        {
            this.hotelService = hotelService;
            this.serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
               Services = this.serviceService.GetAllPopular<ServiceNameViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Hotels = this.hotelService
                .GetByServices<HotelInListViewModel>(input.Services),
            };
            return this.View(viewModel);
        }
    }
}
