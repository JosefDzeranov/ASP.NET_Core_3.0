using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "не указан логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "не указан пароль")]
        public string Password { get; set; }
       
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
