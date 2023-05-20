using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerCore.Models;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

public class DevelopersController : Controller
{
    private readonly UserManager<UserModel> _userManager;

    public DevelopersController(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    // GET
    public IActionResult Index()
    {
        var developers = new List<UserViewModel>();
        return View(developers);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Add(UserViewModel developer)
    {
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel developer)
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        return RedirectToAction("Index");
    }
}