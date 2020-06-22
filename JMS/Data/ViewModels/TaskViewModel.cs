using JMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.ViewModels
{
    public class TaskViewModel: BaseViewModel
    {
        public IEnumerable<SelectListItem> Users { get; set; }

        public string UserID { get; set; }

        public IQueryable<UserTask> UsersTasks { get; set; }

        public UserTask Task { get; set; }
    }
}
