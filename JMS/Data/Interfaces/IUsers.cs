using JMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Data.Interfaces
{
    public interface IUsers
    {
        IQueryable<User> Users { get; }

        User GetUser(int userId);
        
        void SaveUser(User user);

        void DeleteUser(int id);
    }
}
