using JMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.Interfaces
{
    public interface ITasks
    {
        IQueryable<UserTask> UserTasks { get; }

        UserTask GetTask(int id);

        void SaveUserTask(UserTask userTask);

        void DeleteUserTask(int id);


    }
}
