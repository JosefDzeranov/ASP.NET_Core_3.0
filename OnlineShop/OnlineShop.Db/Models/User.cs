using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
    }
}
