
using JMS.Data.Interfaces;
using JMS.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace JMS.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(ITasks userTasks, IUsers usersRep):base(userTasks, usersRep)
        {
            sideBarState.HomeActive = "active";
        }

        public IActionResult Index()
        {
            TaskViewModel model = new TaskViewModel();
            model.SideBarState = sideBarState;
            model.UsersTasks = _tasksRep.UserTasks.Where(x=>x.CloseDateTime>DateTime.Now).OrderBy(x => x.CloseDateTime).Take(3);
            
            ViewBag.Title = "";
            return View(model);
        }
    }
}
