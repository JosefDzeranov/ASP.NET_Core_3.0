using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassWord
    {
        
        [Required(ErrorMessage = "не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

        public string UserName { get; set; }


    }
}
