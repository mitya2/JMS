using JMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;


namespace JMS.Data
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {

        }

        public new DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "5ec87454-8bf5-4703-b8e8-89851fea876d",
                Name = "admin"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c8836f0d-2797-4412-8ef4-5096f985742d",
                UserName = "admin",
                Email = "mitya2@yahoo.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "5ec87454-8bf5-4703-b8e8-89851fea876d",
                UserId = "c8836f0d-2797-4412-8ef4-5096f985742d",
            });

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, Phone = "+79166043064", UserName = "Панов Д.В." },
                new User { id = 2, Phone = "+79166043064", UserName = "Иванов И.И." },
                new User { id = 3, Phone = "+79166043064", UserName = "Петров П.П." });

            modelBuilder.Entity<UserTask>().HasData(
                    new UserTask
                    {
                        id = 1,
                        Content = "Прокачать навык в ASP.NET CORE MVC",
                        InitialDateTime = DateTime.Now.AddDays(-10),
                        CloseDateTime = DateTime.Now.AddDays(14),
                        UserID = 1
                    },
                    new UserTask
                    {
                        id = 2,
                        Content = "Познакомиться с Vue.js",
                        InitialDateTime = DateTime.Now.AddDays(-10),
                        CloseDateTime = DateTime.Now.AddDays(10),
                        UserID = 2
                    },
                    new UserTask
                    {
                        id = 3,
                        Content = "Прокачать навык в Bootstrap",
                        InitialDateTime = DateTime.Now.AddDays(-2),
                        CloseDateTime = DateTime.Now.AddDays(7),
                        UserID = 3
                    },
                    new UserTask
                    {
                        id = 4,
                        Content = "Углубить знания по LINQ",
                        InitialDateTime = DateTime.Now.AddDays(-1),
                        CloseDateTime = DateTime.Now.AddDays(1),
                        UserID = 1
                    },
                    new UserTask
                    {
                        id = 5,
                        Content = "В очередной раз прочитать про паттерны программирования",
                        InitialDateTime = DateTime.Now.AddDays(-10),
                        CloseDateTime = DateTime.Now,
                        UserID = 2
                    },
                    new UserTask
                    {
                        id = 6,
                        Content = "Вспомнить MS SQL",
                        InitialDateTime = DateTime.Now.AddDays(-2),
                        CloseDateTime = DateTime.Now,
                        UserID = 3
                    });
        }
    }
}
