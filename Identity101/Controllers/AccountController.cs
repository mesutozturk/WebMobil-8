using Microsoft.AspNetCore.Mvc;

namespace Identity101.Controllers;

public class Account : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string i)
    {
        return View();
    }
}