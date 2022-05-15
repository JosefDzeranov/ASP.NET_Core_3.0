using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        [Required(ErrorMessage ="не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "не указана фамлия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {

        }

    }
}
