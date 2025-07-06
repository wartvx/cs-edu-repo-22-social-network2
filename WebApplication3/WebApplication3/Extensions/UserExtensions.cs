//-
using System;

using WebApplication3.Models;
using WebApplication3.ViewModels;


namespace WebApplication3.Extensions;

public static class UserExtensions
{
    // UserFromModel
    public static User Convert(this User user, UserEditViewModel usereditvm)
    {
        user.Image = usereditvm.Image;
        user.LastName = usereditvm.LastName;
        user.MiddleName = usereditvm.MiddleName;
        user.FirstName = usereditvm.FirstName;
        user.Email = usereditvm.Email;
        user.BirthDate = usereditvm.BirthDate;
        user.UserName = usereditvm.UserName;
        user.Status = usereditvm.Status;
        user.About = usereditvm.About;

        return user;
    }
}
