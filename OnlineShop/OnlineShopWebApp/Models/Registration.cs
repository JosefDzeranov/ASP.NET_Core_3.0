using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        [Required(ErrorMessage ="Не указан логин")]
        [EmailAddress]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
