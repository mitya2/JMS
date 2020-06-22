using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.ViewModels
{
    public class SideBarState
    {
        public string HomeActive { get; set; }
        public string ReportsActive { get; set; }
        public string UserActive { get; set; }
        public string TaskActive { get; set; }
        public int UsersCount { get; set; }
        public int TasksCount { get; set; }
        public int FinishedTasksCount { get; set; }
    }
}
