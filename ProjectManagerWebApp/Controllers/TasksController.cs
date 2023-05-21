using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

[Authorize]
public class TasksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details()
    {
        return PartialView();
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Edit(TaskViewModel project)
    {
        return RedirectToAction("Index");
    }
}