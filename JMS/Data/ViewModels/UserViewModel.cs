using JMS.Models;
using System.Linq;

namespace JMS.Data.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        public IQueryable<User> Users { get; set; }

        public User User { get; set; }
    }
}
