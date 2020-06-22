using JMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Service
{
    public class Support
    {
        public static IEnumerable<SelectListItem> UsersToList(IQueryable<User> users)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            foreach (var item in users)
            {
                result.Add(new SelectListItem { Value = item.id.ToString(), Text = item.UserName });
            }

            return result;
        }
    }
}
