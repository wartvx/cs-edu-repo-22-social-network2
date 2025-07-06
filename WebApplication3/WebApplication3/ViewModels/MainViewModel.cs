//-
using System;


namespace WebApplication3.ViewModels;

public class MainViewModel
{
    public RegisterViewModel RegisterView { get; set; }

    public LoginViewModel LoginView { get; set; }

    public MainViewModel()
    {
        RegisterView = new RegisterViewModel();
        LoginView = new LoginViewModel { ReturnUrl = "/Home/Index" };
    }
}

