using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class Authorization
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
