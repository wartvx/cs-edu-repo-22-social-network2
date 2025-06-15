//-
using System;

using WebApplication3.Models;


namespace WebApplication3.ViewModels;

public class UserViewModel
{
    public User User { get; set; }

    public UserViewModel(User user)
    {
        User = user;
    }
}
