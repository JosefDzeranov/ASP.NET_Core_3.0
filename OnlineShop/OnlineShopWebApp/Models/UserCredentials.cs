using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserCredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
