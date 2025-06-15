//-
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using AutoMapper;

using WebApplication3.Models;
using WebApplication3.ViewModels;


namespace WebApplication3.Controllers;

public class AccountManagerController : Controller
{
    private readonly ILogger<AccountManagerController> _logger;
    private IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountManagerController(
        ILogger<AccountManagerController> logger,
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    // GET: AccountManagerController
    public ActionResult Index()
    {
        return View();
    }


    [Route("Login")]

    [HttpGet]
    public IActionResult Login()
    {
        return View("Home/Login");
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = "")
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }


    [Route("Login")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _mapper.Map<User>(model);

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName ?? string.Empty, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
        }
        // return View("Views/Home/Index.cshtml");
        return View(model);
    }


    [Route("Logout")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }


    [Authorize]
    [Route("MyPage")]
    [HttpGet]
    public IActionResult MyPage() 
    {
        var user = base.User;

        var result = _userManager.GetUserAsync(user);

        return View("User", new UserViewModel(result.Result));
    }
}
