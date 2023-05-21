using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApplication.Services.Implementations;
using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure.Managers;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

[Authorize]
public class ProjectsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IProjectService _projectService;
    private readonly CustomUserManager _userManager;

    public ProjectsController(IMapper mapper, IProjectService projectService, CustomUserManager userManager)
    {
        _mapper = mapper;
        _projectService = projectService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        //Ленивую подгрузка может пофиксить
        var p = _projectService.GetAll();
        var projects = _projectService.GetAll().Where(p => p.Users.Contains(user)).ToList();
        var projectViews = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            var projectView = _mapper.Map<ProjectViewModel>(project);
            projectViews.Add(projectView);
        }

        return View(projectViews);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Create(ProjectViewModel newProject)
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);
        
        var project = _mapper.Map<ProjectModel>(newProject);
        var PmRole = 2;
        _userManager.AddProjectRole(user, project, PmRole);
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