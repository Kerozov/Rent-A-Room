namespace RentARoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using RentARoom.Common;
    using RentARoom.Data.Common.Models;
    using RentARoom.Services.Data;
    using RentARoom.Web.ViewModels.Hotels;

    public class BookingController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IHotelsServices hotelsServices;
        private readonly IWebHostEnvironment environment;

        public BookingController(
            ICategoriesService categoriesService,
            IHotelsServices hotelsServices,
            IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.hotelsServices = hotelsServices;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new ViewModels.Hotels.AddHotelsInputViewModel
            {
                CategoriesItems = this.categoriesService.GetAllKeysValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddHotelsInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllKeysValuePairs();
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            try
            {
                await this.hotelsServices.CreateAsync(input, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CategoriesItems = this.categoriesService.GetAllKeysValuePairs();
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult MostPopular(int id = 1)
        {
            const int itemsPerPage = 12;

            var viewModel = new HotelListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                HotelsCount = this.hotelsServices.GetCount(),
                Hotels = this.hotelsServices.GetMostPopular<HotelInListViewModel>(id, itemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var hotel = this.hotelsServices.GetById<SingleHotelViewModel>(id);
            return this.View(hotel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.hotelsServices.GetById<EditHotelInputViewModel>(id);
            inputModel.CategoriesItems = this.categoriesService.GetAllKeysValuePairs();
            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHotelInputViewModel input)
        {
            var inputModel = this.hotelsServices.GetById<EditHotelInputViewModel>(id);
            if (!this.ModelState.IsValid)
            {
                inputModel.CategoriesItems = this.categoriesService.GetAllKeysValuePairs();
                return this.View(inputModel);
            }

            await this.hotelsServices.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }
    }
}
