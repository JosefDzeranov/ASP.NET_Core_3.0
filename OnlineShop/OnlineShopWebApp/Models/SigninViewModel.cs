using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class SigninViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес эл.почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}