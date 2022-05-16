using Microsoft.AspNetCore.Mvc;

namespace WissenShop.Web.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}