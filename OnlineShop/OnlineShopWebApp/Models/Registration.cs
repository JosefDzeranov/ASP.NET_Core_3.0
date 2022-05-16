using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models.Attributes;
using System.ComponentModel.DataAnnotations;


namespace OnlineShopWebApp.Models
{
    [NamePassword]
    [RegistrLengthName]
    public class Registration
    {
        [Remote(action: "CheckName", controller: "Registration", ErrorMessage = "Это имя уже используется")]
        [Required(ErrorMessage = "Введите логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
