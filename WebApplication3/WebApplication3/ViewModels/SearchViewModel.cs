//-
using System;
using System.Collections.Generic;


namespace WebApplication3.ViewModels;

public class SearchViewModel
{
    public List<UserWithFriendExtViewModel> UserList { get; set; }
    public SearchViewModel()
    {
        UserList = [];
    }
}
