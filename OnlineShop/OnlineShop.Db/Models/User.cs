using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }       
        public string Age { get; set; }       
    }
}
