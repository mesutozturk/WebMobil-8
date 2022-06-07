using Microsoft.AspNetCore.Mvc;
using North.Web.Models;
using System.Diagnostics;
using North.Businesss.Repositories.Abstracts;
using North.Core.Entities;

namespace North.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product, int> _productRepo;

        public HomeController(ILogger<HomeController> logger, IRepository<Product, int> productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var model = _productRepo
                .Get()
                .ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}