//-
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

using WebApplication3.Models;
using WebApplication3.ViewModels;


namespace WebApplication3.Controllers;

public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;
    private IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public RegisterController(
        ILogger<RegisterController> logger,
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    // GET: RegisterController
    public ActionResult Index()
    {
        return View();
    }


    [Route("Register")]
    [HttpGet]
    public IActionResult Register()
    {
        return View("Home/Register");
    }


    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _mapper.Map<User>(model);
            
            var result = await _userManager.CreateAsync(user, model.PasswordReg);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View("RegisterPart2", model);
    }





    [Route("RegisterPart2")]
    [HttpGet]
    public IActionResult RegisterPart2(RegisterViewModel model)
    {
        model.Login = Guid.NewGuid().ToString();
        return View("RegisterPart2", model);
    }
}

