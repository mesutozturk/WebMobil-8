using Identity101.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity101.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    //[AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AllUsers()
    {
        var users = _userManager.Users
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.Email
            }).ToList();
        return Ok(users);
    }
}