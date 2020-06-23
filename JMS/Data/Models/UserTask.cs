using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMS.Models
{
    /// <summary>
    /// Класс Задание
    /// </summary>
  
    public class UserTask
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Содержание задания не должно быть пустым")]
        [Display(Name = "Содержание задания")]
        public string Content { get; set; }

        [Display(Name = "Дата выдачи задания")]
        public DateTime InitialDateTime { get; set; }

        [Required]
        [Display(Name = "Дата выполнения задания")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CloseDateTime { get; set; }

        [Display(Name = "Сотрудник")] 
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
