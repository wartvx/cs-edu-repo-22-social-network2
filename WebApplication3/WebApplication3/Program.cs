//-
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AutoMapper;

using WebApplication3.Tools;
using WebApplication3.Models;
using WebApplication3.Extensions;


namespace WebApplication3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Подключаем автомаппинг
        var mapperConfig = new MapperConfiguration(v =>
        {
            v.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);


        // получаем строку подключения из файла конфигурации
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        // обновляем публичные значения реальными значениями из приватной области
        connection = ConnectionTools.GetConnectionString(connection);

        /*
        // добавляем контекст ApplicationContext в качестве сервиса в приложение
        builder.Services
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

        builder.Services
            .AddUnitOfWork()
        
        // модель работы с пользователями и работа с EF
        //  дефолтные значения: максимальная степень защиты
        //  — требуются буквы, цифры, заглавные буквы, длина пароля от 12 символов
        // IdentityRole -  базовая роль Identity
        builder.Services
            .AddIdentity<User, IdentityRole>(opts => {
                    opts.Password.RequiredLength = 5;   
                    opts.Password.RequireNonAlphanumeric = false;  
                    opts.Password.RequireLowercase = false; 
                    opts.Password.RequireUppercase = false; 
                    opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
        */

        builder.Services
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
            .AddUnitOfWork()
                .AddCustomRepository<Friend, FriendsRepository>()
                .AddCustomRepository<Message, MessageRepository>()
            .AddIdentity<User, IdentityRole>(opts => {
                    opts.Password.RequiredLength = 5;   
                    opts.Password.RequireNonAlphanumeric = false;  
                    opts.Password.RequireLowercase = false; 
                    opts.Password.RequireUppercase = false; 
                    opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
