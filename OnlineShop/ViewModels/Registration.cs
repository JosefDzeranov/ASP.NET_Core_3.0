using Domains;
using System.ComponentModel.DataAnnotations;
using ViewModels.Attributes;

namespace ViewModels
{
    [NamePassword]
    [RegistrLengthName]
    public class Registration
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }

        public User ToUser(string login)
        {
            return new User(login);
        }
    }
}
