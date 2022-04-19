using Microsoft.AspNetCore.Mvc;

namespace AdminTemplate.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}