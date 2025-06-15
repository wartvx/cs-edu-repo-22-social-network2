//-
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace WebApplication3.Models;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
    {
        Database.EnsureCreated();
    }
}
