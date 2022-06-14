using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassword
    {
        public string Login { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Проверочный пароль должен совпадать с паролем")]
        public string PasswordConfirm { get; set; }
    }
}
