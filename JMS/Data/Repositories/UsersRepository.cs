using JMS.Data.Interfaces;
using JMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.Repositories
{
    public class UsersRepository : IUsers
    {
        private readonly AppDBContext appDBContext;

        public UsersRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IQueryable<User> Users 
        {
            get { return appDBContext.Users; }
        }

        public User GetUser(int Id)
        {
            return appDBContext.Users.FirstOrDefault(p => p.id == Id);
        }

        public void SaveUser(User user)
        {
            if (user.id == default)
                appDBContext.Entry(user).State = EntityState.Added;
            else
                appDBContext.Entry(user).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            appDBContext.Remove(new User { id = id });
            appDBContext.SaveChanges();
        }
    }
}
