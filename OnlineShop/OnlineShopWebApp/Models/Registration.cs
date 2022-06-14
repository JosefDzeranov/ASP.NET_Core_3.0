using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        public Registration()
        {

        }

        public Registration(string userName, string phone, string password, string confirmPassword, string login)
        {
            UserName = userName;
            Phone = phone;
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 25 символов")]
        public string UserName { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
