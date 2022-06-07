
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не заполнено подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword{ get; set; }
    }
}