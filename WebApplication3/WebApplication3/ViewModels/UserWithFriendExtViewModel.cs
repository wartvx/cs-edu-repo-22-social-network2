//-
using System;

using WebApplication3.Models;


namespace WebApplication3.ViewModels;

public class UserWithFriendExtViewModel : User
{
    public bool IsFriendWithCurrent { get; set; }
}
