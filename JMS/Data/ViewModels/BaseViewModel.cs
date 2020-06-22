using JMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.ViewModels
{
    public abstract class BaseViewModel
    {
        public SideBarState SideBarState { get; set; }
    }
}
