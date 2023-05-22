using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure.Managers;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

[Authorize]
public class BoardController : Controller
{
    private int _projectId;
    private readonly IMapper _mapper;
    private readonly ITaskService _taskService;
    private readonly CustomUserManager _userManager;
    private readonly IProjectService _projectService;

    public BoardController(IMapper mapper, ITaskService taskService, IProjectService projectService, CustomUserManager userManager)
    {
        _mapper = mapper;
        _taskService = taskService;
        _userManager = userManager;
        _projectService = projectService;
    }

    private UserModel GetCurrentUser()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        return user;
    }

    // GET
    public IActionResult Index(int id)
    {
        _projectId = id;
        //var tasks = _taskService.GetProjectTasks(id);
        var tasks = _projectService.GetProjectTasks(_projectId);
        var taskViews = new List<TaskViewModel>();
        foreach (var task in tasks)
        {
            var projectView = _mapper.Map<TaskViewModel>(task);
            taskViews.Add(projectView);
        }

        return View(taskViews);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var task = _taskService.GetById(id);
        var taskView = _mapper.Map<TaskViewModel>(task);

        return PartialView(taskView);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Create(TaskViewModel newTask)
    {
        var user = GetCurrentUser();

        var task = _mapper.Map<TaskModel>(newTask);
        task.Appender = user;
        _taskService.Add(task);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult Edit(TaskViewModel editedTask)
    {
        var task = _taskService.GetById(editedTask.Id);
        var taskView = _mapper.Map<TaskViewModel>(task);

        return PartialView(taskView);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _taskService.DeleteById(id);
        return RedirectToAction("Index");
    }
}