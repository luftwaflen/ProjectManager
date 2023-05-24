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
    private readonly IWorkTimeService _workTimeService;

    public TasksController(IMapper mapper, ITaskService taskService, CustomUserManager userManager,
        IWorkTimeService workTimeService)
    {
        _mapper = mapper;
        _taskService = taskService;
        _userManager = userManager;
        _workTimeService = workTimeService;
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
        var user = GetCurrentUser();
        var task = _taskService.GetById(id);
        var workTime = _workTimeService.GetTaskWorkTime(user, task);
        var wkView = _mapper.Map<WorkTimeViewModel>(workTime);

        return PartialView(wkView);
    }

    [HttpPost]
    public IActionResult Edit(WorkTimeViewModel workTimeView)
    {
        var user = GetCurrentUser();
        var task = _taskService.GetById(workTimeView.Task.Id);

        var workTime = _workTimeService.GetTaskWorkTime(user, task);
        var newHours = workTime.Time.Hours + workTimeView.Hours;
        var newMinutes = workTime.Time.Minutes + workTimeView.Minutes;
        var newTime = new TimeSpan(0,newHours,newMinutes,0);
        workTime.Time = newTime;
        _workTimeService.Update(workTime);

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _taskService.DeleteById(id);
        return RedirectToAction("Index");
    }
}