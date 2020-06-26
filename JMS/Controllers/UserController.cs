
using JMS.Data.Interfaces;
using JMS.Data.ViewModels;
using JMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMS.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(ITasks userTasks, IUsers usersRep) : base(userTasks, usersRep)
        {
            sideBarState.UserActive = "active";
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var entity = (id == default) ? new User() : _usersRep.GetUser(id);

            UserViewModel model = new UserViewModel();
            model.SideBarState = sideBarState;
            model.User = entity;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

                _usersRep.SaveUser(model.User);
                return RedirectToAction("List");
            }
            model.SideBarState = sideBarState;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(UserViewModel model)
        {
            _usersRep.DeleteUser(model.User.id);
            return RedirectToAction("List");
        }

        [AllowAnonymous]
        public IActionResult List()
        {
            UserViewModel model = new UserViewModel();
            model.SideBarState = sideBarState;
            model.Users = _usersRep.Users;
            return View(model);
        }
    }
}
