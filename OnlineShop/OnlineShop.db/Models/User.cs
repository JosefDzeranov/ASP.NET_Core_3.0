using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineShop.db.Models
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarPath { get; set; }
        public string? Email { get; set; }
        public string Id { get; set; }
        public string? Phone { get; set; }
    }
}
