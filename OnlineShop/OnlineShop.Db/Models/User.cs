using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {      
        public string Age { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
