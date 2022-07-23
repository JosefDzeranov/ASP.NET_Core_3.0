using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Authorization
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress]
        public string Login { get; set; } 

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
