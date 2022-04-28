using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class UserCredentials
    {
 
        [Required(ErrorMessage ="Не указан e-mail")]
        [EmailAddress(ErrorMessage ="Введите корректный e-mail")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        public string Password { get; set; }  
        public bool RememberMe { get; set; }
    }
}
