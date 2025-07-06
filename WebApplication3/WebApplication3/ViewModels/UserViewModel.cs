//-
using System;
using System.Collections.Generic;

using WebApplication3.Models;


namespace WebApplication3.ViewModels;

public class UserViewModel
{
    public User User { get; set; }

    public List<User> Friends { get; set; }

    public UserViewModel(User user)
    {
        User = user ?? new User();
        Friends = [];
    }
}
