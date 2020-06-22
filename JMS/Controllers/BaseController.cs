using System.Linq;
using JMS.Data.Interfaces;
using JMS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JMS.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ITasks _tasksRep;
        protected readonly IUsers _usersRep;
        protected SideBarState sideBarState = new SideBarState();

        protected BaseController(ITasks userTasksRep, IUsers usersRep)
        {
            _tasksRep = userTasksRep;
            _usersRep = usersRep;
            
            sideBarState.TasksCount = _tasksRep.UserTasks.Count();
            sideBarState.UsersCount = _usersRep.Users.Count();
        }
    }
}
