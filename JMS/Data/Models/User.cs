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
        [Key]
        public int id { get; set; }

        [Display(Name = "Имя сотрудника")]
        [StringLength(20)]
        [Required(ErrorMessage = "Имя сотрудника должно содержать от 1 до 20 символов", AllowEmptyStrings = false)] 
        public string UserName { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12, ErrorMessage = "Номер телефона должен содержать 12 символов (например, +74951234567)", MinimumLength = 12)]
        [Required(ErrorMessage = "Необходимо ввести номер телефона", AllowEmptyStrings = false)]
        public string Phone { get; set; }
        
        public List<UserTask> Tasks { get; set; }
    }
}
