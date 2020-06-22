using JMS.Data.Interfaces;
using JMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.Repositories
{
    public class TasksRepository : ITasks
    {
        private readonly AppDBContext appDBContext;

        public TasksRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IQueryable<UserTask> UserTasks
        {
            get { return appDBContext.UserTasks.Include(u=>u.User); }
        }

        public UserTask GetTask(int Id)
        {
           return appDBContext.UserTasks.FirstOrDefault(p => p.id == Id);
        }

        public void SaveUserTask(UserTask userTask)
        {
            if (userTask.id == default)
                appDBContext.Entry(userTask).State = EntityState.Added;
            else
                appDBContext.Entry(userTask).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }

        public void DeleteUserTask(int id)
        {
            appDBContext.Remove(new UserTask { id = id });
            appDBContext.SaveChanges();
        }
    }
}
