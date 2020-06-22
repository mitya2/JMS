using JMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public static void Initial(AppDBContext appDBContext)
        {
            if (!appDBContext.Users.Any())
            {
                appDBContext.Users.AddRange(
                    new User { Phone = "+79166043064", UserName = "Панов Д.В." },
                    new User { Phone = "+79166043064", UserName = "Иванов И.И." },
                    new User { Phone = "+79166043064", UserName = "Петров П.П." });
                
                appDBContext.SaveChanges();
            }

            User us = appDBContext.Users.First();

            if (!appDBContext.UserTasks.Any())
            {
                appDBContext.UserTasks.AddRange(
                    new UserTask
                    {
                        Content = "Прокачать навык в ASP.NET CORE MVC",
                        InitialDateTime = DateTime.Now,
                        CloseDateTime = DateTime.Now.AddDays(14),
                        User = us
                    },
                    new UserTask
                    {
                        Content = "Прокачать навык в Bootstrap",
                        InitialDateTime = DateTime.Now,
                        CloseDateTime = DateTime.Now.AddDays(7),
                        User = us
                    },
                    new UserTask
                    {
                        Content = "Вспомнить MS SQL",
                        InitialDateTime = DateTime.Now,
                        CloseDateTime = DateTime.Now.AddDays(3),
                        User = us
                    }); ;

                appDBContext.SaveChanges();
            }

            
        }
        /*        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);

                    User user = new User
                    {
                        id = 1,
                        Phone = "+79166043064",
                        UserName = "Панов Д.В."
                    };

                    modelBuilder.Entity<User>().HasData(user);

                    modelBuilder.Entity<UserTask>().HasData(new UserTask
                    {
                        id = 1,
                        Content = "Прокачать навык в ASP.NET CORE MVC",
                        InitialDateTime = DateTime.Now,
                        CloseDateTime = DateTime.Now.AddDays(14),
                        UserID = 1,
                        User = user
                    });
                }*/
    }
}
