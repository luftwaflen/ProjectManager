using Microsoft.AspNetCore.Mvc;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

public class ProjectsController : Controller
{
    public ProjectsController()
    {
    }

    public IActionResult Index()
    {
        //Через jwt получаем claim с инфой о пользователе
        //var id = this.User.FindFirst("asd").Value;
        
        var projects = new List<ProjectViewModel>();
        return View(projects);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Create(ProjectViewModel newProject)
    {
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Edit(ProjectViewModel project)
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete()
    {
        return RedirectToAction("Index");
    }
}