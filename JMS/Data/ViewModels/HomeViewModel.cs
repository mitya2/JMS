using JMS.Models;
using System.Linq;

namespace JMS.Data.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IQueryable<UserTask> UsersTasks { get; set; }

    }
}
