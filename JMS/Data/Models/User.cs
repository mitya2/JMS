using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Models
{
    /// <summary>
    /// Класс Сотрудник
    /// </summary>
    public class User
    {
        public int id { get; set; }

        [Display(Name = "Имя сотрудника")]
        [StringLength(20)]
        [Required(ErrorMessage = "Имя сотрудника не более 20 символов", AllowEmptyStrings = false)] 
        public string UserName { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Длина номера телефона не более 12 символов", AllowEmptyStrings = false)]
        public string Phone { get; set; }
        
        public List<UserTask> Tasks { get; set; }
    }
}
