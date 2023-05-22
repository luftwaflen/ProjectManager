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
public class TasksController : Controller
{
    private readonly IMapper _mapper;
    private readonly ITaskService _taskService;
    private readonly CustomUserManager _userManager;

    public TasksController(IMapper mapper, ITaskService taskService, CustomUserManager userManager)
    {
        _mapper = mapper;
        _taskService = taskService;
        _userManager = userManager;
    }

    private UserModel GetCurrentUser()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        return user;
    }

    // GET
    public IActionResult Index()
    {
        var user = GetCurrentUser();

        var tasks = _taskService.GetUserTasks(user.Id);
        var taskViews = new List<TaskViewModel>();
        foreach (var task in tasks)
        {
            var projectView = _mapper.Map<TaskViewModel>(task);
            taskViews.Add(projectView);
        }

        return View(taskViews);
    }

    public IActionResult Details(int id)
    {
        var task = _taskService.GetById(id);
        var taskView = _mapper.Map<TaskViewModel>(task);

        return PartialView(taskView);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _taskService.GetById(id);
        var taskView = _mapper.Map<TaskViewModel>(task);

        return PartialView(taskView);
    }

    [HttpPost]
    public IActionResult Edit(TaskViewModel task)
    {
        var user = GetCurrentUser();

        var taskModel = _mapper.Map<TaskModel>(task);
        _taskService.Update(taskModel);

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _taskService.DeleteById(id);
        return RedirectToAction("Index");
    }
}