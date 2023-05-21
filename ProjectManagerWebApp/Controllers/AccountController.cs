using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure.Managers;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Controllers;

public class AccountController : Controller
{
    private readonly CustomUserManager _userManager;
    private readonly SignInManager<UserModel> _signInManager;

    public AccountController(CustomUserManager userManager, SignInManager<UserModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            UserModel user = new UserModel
            {
                UserName = register.Name,
                Email = register.Email
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Projects");
            }

            ModelState.AddModelError("", result.Errors.ToString());
        }

        return View(register);
    }

    public IActionResult Login(string returnUrl = null)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var user = _userManager.Users.First(u => u.UserName == login.Name);
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Projects");
            }

            ModelState.AddModelError("", "Wrong login or password");
        }

        return View(login);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}