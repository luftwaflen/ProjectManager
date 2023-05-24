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

    private UserModel GetCurrentUser()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        return user;
    }
    
    public IActionResult Index()
    {
        var user = GetCurrentUser();

        ViewData["User"] = user;
        ViewData["UserManager"] = _userManager;
        ViewData["ProjectService"] = _projectService;

        var projects = _projectService.GetUserProjects(user.Id);
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
        var user = GetCurrentUser();
        
        var project = _mapper.Map<ProjectModel>(newProject);
        var PmRole = 2;
        _userManager.AddProjectRole(user, project, PmRole);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var project = _projectService.GetById(id);
        var projectView = _mapper.Map<ProjectViewModel>(project);
        return PartialView(projectView);
    }

    [HttpPost]
    public IActionResult Edit(ProjectViewModel project)
    {
        var user = GetCurrentUser();

        var projectModel = _mapper.Map<ProjectModel>(project);
        _projectService.Update(projectModel);
        
        return RedirectToAction("Index");
    }

    //[HttpPost]
    public IActionResult Delete(int id)
    {
        _projectService.DeleteById(id);
        return RedirectToAction("Index");
    }
}