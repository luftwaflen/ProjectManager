using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure.Managers;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

[Authorize]
public class DevelopersController : Controller
{
    private readonly IMapper _mapper;
    private readonly CustomUserManager _userManager;
    private readonly IProjectService _projectService;

    public DevelopersController(IMapper mapper, CustomUserManager userManager, IProjectService projectService)
    {
        _mapper = mapper;
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
        var user = GetCurrentUser();
        var project = _projectService.GetById(id);

        ViewData["UserRole"] = _userManager.GetUserRole(user, project);
        var projectUsers = _projectService.GetProjectUsers(id);
        var developers = new List<UserViewModel>();
        foreach (var projectUser in projectUsers)
        {
            var dev = _mapper.Map<UserViewModel>(projectUser);
            developers.Add(dev);
        }

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
        var userModel = _userManager.FindByEmailAsync(developer.Email);
        var user = _mapper.Map<UserModel>(userModel.Result);
        var roleId = 1;
        _projectService.AddUserToProject(StaticData.ProjectId, user, roleId);

        return RedirectToAction("Index", new { id = StaticData.ProjectId });
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _userManager.Users.First(u => u.Id == id);
        var userView = _mapper.Map<UserViewModel>(user);
        return PartialView(userView);
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel developer)
    {
        var project = _projectService.GetById(StaticData.ProjectId);
        var user = _userManager.FindByNameAsync(developer.UserName).Result;
        _userManager.ChangeProjectRole(user, project, developer.Role);

        return RedirectToAction("Index", new { id = StaticData.ProjectId });
    }

    //[HttpPost]
    public IActionResult Delete(int id)
    {
        var user = _userManager.Users.First(u => u.Id == id);
        _userManager.DeleteAsync(user);

        return RedirectToAction("Index", new { id = StaticData.ProjectId });
    }
}