using JMS.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace JMS.Models
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Логин не должен быть пустым", AllowEmptyStrings = false)]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [UIHint("password")]
        [Required(ErrorMessage = "Пароль не должен быть пустым", AllowEmptyStrings = false)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
