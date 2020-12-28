namespace RentARoom.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using RentARoom.Data;
    using RentARoom.Services.Data;
    using RentARoom.Web.ViewModels;
    using RentARoom.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IHotelsServices hotelsServices;

        public HomeController(
            ApplicationDbContext db,
            IHotelsServices hotelsServices)
        {
            this.db = db;
            this.hotelsServices = hotelsServices;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Hotels = this.hotelsServices.GetRandom<IndexPageHotelViewModel>(10),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult StatusCodeError(int errorCode)
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
