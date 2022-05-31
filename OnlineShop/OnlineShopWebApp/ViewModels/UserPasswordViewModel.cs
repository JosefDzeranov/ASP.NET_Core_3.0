using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class UserPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан старый пароль")]
        public string OldPassword { get; set; }
       
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повтор пароля")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
