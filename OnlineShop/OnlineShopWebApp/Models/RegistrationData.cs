using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите возраст")]
        [Range(18, 110, ErrorMessage = "Недопустимый возраст")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }        

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}
