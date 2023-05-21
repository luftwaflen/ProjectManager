using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

[Authorize]
public class BoardController : Controller
{
    private readonly int _projectId;
    public BoardController()
    {
    }

    // GET
    public IActionResult Index()
    {
        var tasks = new List<TaskViewModel>();
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return PartialView();
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Create(TaskViewModel newProject)
    {
        return RedirectToAction("Index");
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

    [HttpPost]
    public IActionResult Delete()
    {
        return RedirectToAction("Index");
    }
}