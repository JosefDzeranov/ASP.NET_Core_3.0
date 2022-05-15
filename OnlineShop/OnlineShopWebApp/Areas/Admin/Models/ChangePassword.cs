using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class ChangePassword
    {
        public User User { get; set; }
        public SignUp Signup { get; set; }
    }
}
