using JMS.Data.Interfaces;
using JMS.Data.ViewModels;
using JMS.Models;
using JMS.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JMS.Controllers
{
    public class TaskController : BaseController
    {
        public TaskController(ITasks userTasks, IUsers usersRep) : base(userTasks, usersRep)
        {
            sideBarState.TaskActive = "active";
        }

        public IActionResult Edit(int id)
        {
            UserTask userTask = (id == default) ? new UserTask() : _tasksRep.GetTask(id);

            TaskViewModel model = new TaskViewModel();
            model.Task = userTask;
            model.Task.User = _usersRep.GetUser(model.Task.UserID);
            
            model.Users = Support.UsersToList(_usersRep.Users);
            model.UserID = model.Task.UserID.ToString();


            model.SideBarState = sideBarState;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Task.UserID = Convert.ToInt32(model.UserID);

                _tasksRep.SaveUserTask(model.Task);
                return RedirectToAction("List");
            }
            model.Users = Support.UsersToList(_usersRep.Users);
            model.UserID = model.Task.UserID.ToString();
            model.SideBarState = sideBarState;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel model)
        {
            _tasksRep.DeleteUserTask(model.Task.id);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            TaskViewModel model = new TaskViewModel();
            model.UsersTasks = _tasksRep.UserTasks;
            model.SideBarState = sideBarState;
            return View(model);
        }
    }
}
