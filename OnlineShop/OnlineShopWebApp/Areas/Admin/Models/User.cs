using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        public string Role { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { } // Empty ctor for XML serializing.

        public User(Guid id, string firstname, string lastname, string role, string phone, string email, string password)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }
}
