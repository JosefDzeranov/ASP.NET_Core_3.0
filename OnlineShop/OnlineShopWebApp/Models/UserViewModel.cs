using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "не указана фамлия")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

     //   public UserActions Actions { get; set; }

        public UserViewModel(string login, string password)
        {
            Login = login;
            Password = password;
            Id = Guid.NewGuid();
        }

        public UserViewModel()
        {

        }

    }
}
