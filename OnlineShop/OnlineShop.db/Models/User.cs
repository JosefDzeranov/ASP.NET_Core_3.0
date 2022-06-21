using Microsoft.AspNetCore.Identity;

namespace OnlineShop.db.Models
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarPath { get; set; }
        public string? Phone { get; set; }
    }
}
