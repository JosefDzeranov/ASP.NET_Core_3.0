
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "не указан пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}