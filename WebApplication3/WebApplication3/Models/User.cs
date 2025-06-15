//-
using System;
using Microsoft.AspNetCore.Identity;


namespace WebApplication3.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public string Image { get; set; }

    public string Status { get; set; }

    public string About { get; set; }


    public User()
    {
        Image = "https://via.placeholder.com/500";
        Status = "Ура! Я в соцсети!";
        About = "Информация обо мне.";
    }


    public string GetFullName()
    {
        return FirstName + " " + MiddleName + " " + LastName;
    }
}
