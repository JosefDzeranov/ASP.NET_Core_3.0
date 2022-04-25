﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "не указано имя")]
        [StringLength(16, MinimumLength =2, ErrorMessage ="имя должно быть от 2 до 16 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указан повтор пароля")]
        [Compare("Password", ErrorMessage ="пароли не совпадают")]
        public string ConfirmPassword{ get; set; }
    }
}
