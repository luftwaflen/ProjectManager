using Microsoft.AspNetCore.Mvc;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

public class AccountController : Controller
{
    public AccountController()
    {
        
    }
    // GET
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel register)
    {
        return RedirectToRoute("/Projects/Index");
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(LoginViewModel login)
    {
        return RedirectToRoute("/Projects/Index");
    }

    public IActionResult Logout()
    {
        return null;
    }
}